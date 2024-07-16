using CWB.App.Models.BusinessProcesses;
using CWB.App.Models.ItemMaster;
using CWB.App.Models.Plants;
using CWB.App.Services.BusinessProcesses;
using CWB.App.Services.CompanySettings;
using CWB.App.Services.Masters;
using CWB.App.Services.ProductionPlanWo;
using CWB.App.Services.Routings;
using CWB.Constants.UserIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.App.Controllers
{
    [Authorize(Roles = Roles.ADMIN)]
    public class WorkOrderController : Controller
    {
        private readonly ILogger<WorkOrderController> _logger;
        private readonly IWOService _woService;
        private readonly IBAService _baService;
        private readonly IRoutingService _routingService;
        private readonly IMastersServices _masterService;
        private readonly IPlantService _plantService;
        public WorkOrderController(ILogger<WorkOrderController> logger, IWOService wOService, IBAService baService, IRoutingService routingService, IMastersServices masterServices, IPlantService plantService)
        {
            _logger = logger;
            _woService = wOService;
            _baService = baService;
            _routingService = routingService;
            _masterService = masterServices;
            _plantService = plantService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SoToWo()
        {
            return View();
        }

        public IActionResult DetailedProcPlan()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AllSalesOrders()
        {
            var salesorders = await _baService.AllSalesOrders();
            var masterparts = await _masterService.ItemMasterParts();
            var customer = await _baService.GetCustomerOrders();
            foreach (SalesOrderVM sovm in salesorders)
            {
                foreach (ItemMasterPartVM impvm in masterparts)
                {
                    if (sovm.PartId == impvm.PartId)
                    {
                        sovm.PartNo = impvm.PartNo;
                        sovm.PartDesc = impvm.Description;
                    }
                }
                foreach (CustomerOrderVM cu in customer)
                {
                    if (sovm.CustomerOrderId == cu.CustomerOrderId)
                    {
                        sovm.Customer = cu.CustomerName;
                        sovm.PoNumber = cu.PONumber;
                    }
                }
            }
            return Ok(salesorders);
        }

        [HttpGet]
        public async Task<IActionResult> AllWorkOrders()
        {
            var workOrders = await _baService.AllWorkOrders();
            var masterparts = await _masterService.ItemMasterParts();
            foreach (WorkOrdersVM item in workOrders)
            {
                foreach (ItemMasterPartVM imp in masterparts)
                {
                    if (item.PartId == imp.PartId)
                    {
                        item.PartNo = imp.PartNo;
                        item.PartDesc = imp.Description;
                    }
                }
            }
            return Ok(workOrders);
        }

        [HttpGet]
        public async Task<IActionResult> ReloadWo(string reloadoption, long partid)
        {
            List<WorkOrdersVM> listwo = new List<WorkOrdersVM>();
            var workOrders = await _baService.AllWorkOrders();
            foreach (var item in workOrders)
            {
                if (item.ReloadOption == reloadoption && item.PartId == partid)
                {
                    listwo.Add(item);
                }
            }
            return Ok(listwo);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoutings(int manufPartId)
        {
            var resultList = await _routingService.Routings(manufPartId);
            return Ok(resultList);
        }

        [HttpGet]
        public async Task<IActionResult> RoutingSteps(int routingId)
        {
            var result = await _routingService.RoutingSteps(routingId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSoWo(long workOrderId)
        {
            var resultList = await _woService.GetSoWoRel(workOrderId);
            return Ok(resultList);
        }

        [HttpPost]
        public async Task<IActionResult> GetOneSO([FromBody] IEnumerable<WOSOVM> saleOrderId)
        {
            List<SalesOrderVM> setSO = new List<SalesOrderVM>();
            foreach (var item in saleOrderId)
            {
                setSO.Add(await _baService.GetOneSO(item.SalesOrderId));

            }
            return Ok(setSO);
        }

        public async Task<IActionResult> GetSoNumber(long soid)
        {
            var so = await _baService.GetOneSO(soid);
            return Ok(so);
        }

        //[HttpPost]
        public async Task<IActionResult> ProcPlan()
        {
            var workOrders = await _baService.AllWorkOrders();
            List<ProductionPlan_WoVM> productions = new List<ProductionPlan_WoVM>();
            foreach (var item in workOrders)
            {
                if (item.Active != 2)
                {
                    ProductionPlan_WoVM production = new ProductionPlan_WoVM
                    {
                        WONumber = item.WONumber,
                        WoId = item.WOID,
                        SalesOrderId = item.SalesOrderId,
                        PartId = item.PartId,
                        PartType = item.PartType,
                        Parentlevel = item.Parentlevel,
                        BuildToStock = item.BuildToStock,
                        TestData = item.TestData,
                        CalcWOQty = item.CalcWOQty,
                        PlanCompletionDate = item.PlanCompletionDate,
                        RoutingId = item.RoutingId,
                        StartingOpNo = item.StartingOpNo,
                        EndingOpNo = item.EndingOpNo,
                        ReloadOption = "",
                        TenantId = item.TenantId,
                    };
                    productions.Add(production);
                }
            }

            var procdutionpost = await _woService.ProductionPlanWoPost(productions);
            if (procdutionpost.Any())
            {
                List<ProcPlanVM> listprocplan = new List<ProcPlanVM>();
                List<BOMListVM> listbom = new List<BOMListVM>();
                int totalLeadTime = 0;
                foreach (var item in procdutionpost)
                {
                    if (item.TestData == 'Y')
                    {
                        ManufacturedPartNoDetailVM mf = await _masterService.GetManufPart((int)item.PartId);
                        if (mf.ManufacturedPartType == 1)
                        {
                            var mpmakefromlist = await _masterService.GetMPMakeFromListByPartId(mf.ManufacturedPartNoDetailId.ToString());
                            var groupedResults = mpmakefromlist.GroupBy(x => x.MPPartId)
                                   .Select(g => new
                                   {
                                       PartId = g.Key,
                                       TotalQuantity = g.Sum(x =>
                                       {
                                           int quantity;
                                           return int.TryParse(x.QuantityPerInput, out quantity) ? quantity : 0;
                                       })
                                   })
                                    .ToList();
                            foreach (var grouped in groupedResults)
                            {
                                var mfpdList = await _masterService.PartPurchasesFor(grouped.PartId);
                                var ptype = await _masterService.GetRMPart(grouped.PartId);
                                totalLeadTime = mfpdList.Sum(x => x.LeadTimeInDays);
                                DateTime nextworkdingdate = (DateTime)item.PlanCompletionDate;
                                nextworkdingdate = nextworkdingdate.AddDays(totalLeadTime);
                                if (groupedResults != null)
                                {
                                    ProcPlanVM ppdata = new ProcPlanVM
                                    {
                                        PartId = grouped.PartId,
                                        PartType = ptype.MasterPartType,
                                        Calc_Proc_Qnty = grouped.TotalQuantity * item.CalcWOQty,
                                        CalcReceiptDate = nextworkdingdate,
                                        WorkOrderId = item.WoId
                                    };
                                    listprocplan.Add(ppdata);
                                }
                            }
                        }
                        else if (mf.ManufacturedPartType == 2)
                        {
                            var bomlst = await _masterService.BOMS(mf.ManufacturedPartNoDetailId.ToString());
                            var bomgroupedResults = bomlst.GroupBy(x => x.BOMPartId)
                                   .Select(g => new
                                   {
                                       PartId = g.Key,
                                       TotalQuantity = g.Sum(x => x.Quantity)
                                   })
                                    .ToList();
                            foreach (var bomgrp in bomgroupedResults)
                            {
                                var mp = await _masterService.ItemMasterPartById(bomgrp.PartId);
                                var workdetails = await _plantService.GetPlantWD(13);
                                var holidaylist = await _plantService.GetHolidays(13);
                                string weekOff1 = workdetails.WeeklyOff1;
                                string weekOff2 = workdetails.WeeklyOff2;

                                switch (mp.MasterPartType)
                                {
                                    case MasterPartType.ManufacturedPart:
                                        var resultList = await _routingService.Routings(bomgrp.PartId);
                                        int minutes = 0;
                                        foreach (var rote in resultList)
                                        {
                                            var result = await _routingService.RoutingSteps(rote.RoutingId);
                                            foreach (var step in result)
                                            {
                                                var stepdetails = await _routingService.StepMachines((int)step.StepId);
                                                var processingTimeSum = stepdetails
                                                                .GroupBy(sd => sd.RoutingStepId)
                                                                .Select(g => new
                                                                {
                                                                    RoutingStepId = g.Key,
                                                                    TotalProcessingTime = g.Sum(sd => TimeSpan.Parse(sd.FirstPieceProcessingTime).TotalMinutes)
                                                                });
                                                foreach (var min in processingTimeSum)
                                                {
                                                    minutes = (int)min.TotalProcessingTime;
                                                }
                                            }
                                        }
                                        int assyTime = (minutes * item.CalcWOQty) / workdetails.NoOfShifts;
                                        int assyTimeInDays = assyTime / 1440;
                                        DateTime planstartdt = item.PlanCompletionDate.Value.AddDays(-assyTimeInDays);

                                        var manufchild = await _masterService.GetManufPart((int)bomgrp.PartId);
                                        var manfDays = 0;

                                        while (!IsWorkDay(planstartdt, holidaylist, weekOff1, weekOff2))
                                        {
                                            planstartdt = planstartdt.AddDays(1);
                                        }
                                        if (manufchild.ManufacturedPartType == 1)
                                        {
                                            DateTime planstdt = planstartdt;
                                            DateTime plancpldt = item.PlanCompletionDate.GetValueOrDefault();
                                            manfDays = Math.Max(0, (plancpldt - planstdt).Days);
                                        }
                                        BOMListVM bomdata = new BOMListVM
                                        {
                                            ParentWoId = item.WoId,
                                            Child_Part_No_ID = bomgrp.PartId,
                                            Child_Part_No_Type = mp.MasterPartType.ToString(),
                                            Calc_Qnty = (int)bomgrp.TotalQuantity * item.CalcWOQty,
                                            Plan_Qnty = item.CalcWOQty,
                                            Plan_Start_Dt = planstartdt,
                                            Plan_Compl_Dt = item.PlanCompletionDate.GetValueOrDefault(),
                                            CalcReceiptDate = planstartdt,
                                            Manf_Days_Avl = manfDays,
                                            ProcPlanId = item.ProductionPlanId
                                        };
                                        listbom.Add(bomdata);
                                        break;
                                    //case MasterPartType.BOM:

                                    //    break;
                                    case MasterPartType.BOF:
                                        var bofpdList = await _masterService.PartPurchasesFor(bomgrp.PartId);
                                        var bofptype = await _masterService.GetRMPart(bomgrp.PartId);
                                        totalLeadTime = bofpdList.Sum(x => x.LeadTimeInDays);
                                        DateTime bofnextworkdingdate = (DateTime)item.PlanCompletionDate;
                                        bofnextworkdingdate = bofnextworkdingdate.AddDays(totalLeadTime);
                                        BOMListVM bofbomdata = new BOMListVM
                                        {
                                            ParentWoId = item.WoId,
                                            Child_Part_No_ID = bomgrp.PartId,
                                            Child_Part_No_Type = mp.MasterPartType.ToString(),
                                            Calc_Qnty = (int)bomgrp.TotalQuantity * item.CalcWOQty,
                                            Plan_Qnty = item.CalcWOQty,
                                            Plan_Compl_Dt = item.PlanCompletionDate.GetValueOrDefault(),
                                            CalcReceiptDate = bofnextworkdingdate,
                                            ProcPlanId = item.ProductionPlanId
                                        };
                                        listbom.Add(bofbomdata);
                                        break;
                                    case MasterPartType.RawMaterial:
                                        var mfpdList = await _masterService.PartPurchasesFor(bomgrp.PartId);
                                        var ptype = await _masterService.GetRMPart(bomgrp.PartId);
                                        totalLeadTime = mfpdList.Sum(x => x.LeadTimeInDays);
                                        DateTime nextworkdingdate = (DateTime)item.PlanCompletionDate;
                                        nextworkdingdate = nextworkdingdate.AddDays(totalLeadTime);

                                        BOMListVM rmbomdata = new BOMListVM
                                        {
                                            ParentWoId = item.WoId,
                                            Child_Part_No_ID = bomgrp.PartId,
                                            Child_Part_No_Type = mp.MasterPartType.ToString(),
                                            Calc_Qnty = (int)bomgrp.TotalQuantity * item.CalcWOQty,
                                            Plan_Qnty = item.CalcWOQty,
                                            Plan_Compl_Dt = item.PlanCompletionDate.GetValueOrDefault(),
                                            CalcReceiptDate = nextworkdingdate,
                                            ProcPlanId = item.ProductionPlanId
                                        };
                                        listbom.Add(rmbomdata);

                                        break;
                                    default:
                                        break;
                                }
                            }

                        }

                    }
                }
                if (listprocplan.Any())
                {
                    var result = await _woService.ProcPlanPost(listprocplan);
                }
                if (listbom.Any())
                {
                    var bomresult = await _woService.BomListPost(listbom);
                }
            }

            return RedirectToAction("DetailedProcPlan");
        }

        [HttpGet]
        public async Task<IActionResult> AllProductionWo()
        {
            var productions = await _woService.AllProductionPlan_Wo();
            var masterparts = await _masterService.ItemMasterParts();
            foreach (ProductionPlan_WoVM item in productions)
            {
                foreach (ItemMasterPartVM imp in masterparts)
                {
                    if (item.PartId == imp.PartId)
                    {
                        item.PartNo = imp.PartNo;
                        item.PartDesc = imp.Description;
                    }
                }
            }
            return Ok(productions);
        }

        [HttpGet]
        public async Task<IActionResult> ReloadProductionWo(string reloadoption, long partid)
        {
            List<ProductionPlan_WoVM> listwo = new List<ProductionPlan_WoVM>();
            var productions = await _woService.AllProductionPlan_Wo();
            foreach (var item in productions)
            {
                if (item.ReloadOption == reloadoption && item.PartId == partid)
                {
                    listwo.Add(item);
                }
            }
            return Ok(listwo);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProcPlan()
        {
            var resultList = await _woService.GetAllProcPlan();
            foreach (ProcPlanVM item in resultList)
            {
                var mp = await _masterService.ItemMasterPartById((int)item.PartId);
                var mfpdList = await _masterService.PartPurchasesFor((int)item.PartId);
                foreach (var purs in mfpdList)
                {
                    if (item.PartId == purs.PPartId)
                    {
                        item.Supplier = purs.PSupplier;
                        item.LeadTimeInDays = purs.LeadTimeInDays.ToString();
                        item.Moq = purs.MinimumOrderQuantity;
                    }
                }
                item.PartNo = mp.PartNo;
                item.PartDesc = mp.PartDescription;
            }
            return Ok(resultList);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBomlist()
        {
            var resultList = await _woService.GetAllBomlist();
            var workOrders = await _baService.AllWorkOrders();
            foreach (BOMListVM item in resultList)
            {
                var mp = await _masterService.ItemMasterPartById((int)item.Child_Part_No_ID);
                item.PartNo = mp.PartNo;
                item.PartDesc = mp.PartDescription;
                foreach (WorkOrdersVM wo in workOrders)
                {
                    if (item.ParentWoId == wo.WOID)
                    {
                        item.WoNumber = wo.WONumber;
                    }
                }
            }
            return Ok(resultList);
        }

        [HttpPost]
        public async Task<IActionResult> MultipleProductionWOPost([FromBody] IEnumerable<ProductionPlan_WoVM> ppwos)
        {
            var procdutionpost = await _woService.ProductionPlanWoPost(ppwos);
            return Ok(procdutionpost);
        }

        [HttpGet]
        public async Task<IActionResult> SplitWo(long woid, string initialDate, int numDays, int quantity, long salersorderId, int partId, int partType)
        {
            var inltialDt = DateTime.Parse(initialDate);
            List<ProductionPlan_WoVM> previousWorkdays = new List<ProductionPlan_WoVM>();
            DateTime currentDate = inltialDt;
            var workdetails = await _plantService.GetPlantWD(13);
            var holidaylist = await _plantService.GetHolidays(13);
            string weekOff1 = workdetails.WeeklyOff1;
            string weekOff2 = workdetails.WeeklyOff2;
            int quantityPerDay = quantity / numDays;

            for (int i = 0; i < numDays; i++)
            {
                do
                {
                    currentDate = currentDate.AddDays(-1);
                } while (!IsWorkDay(currentDate, holidaylist, weekOff1, weekOff2));

                ProductionPlan_WoVM dailywo = new ProductionPlan_WoVM
                {
                    ParentWoId = woid,
                    SalesOrderId = salersorderId,
                    CalcWOQty = quantityPerDay,
                    PlanCompletionDate = currentDate,
                    PartId = partId,
                    PartType = partType,
                    For_Ref = 'N',
                    ReloadOption = "Split"
                };
                previousWorkdays.Add(dailywo);
            }
            //var postWO = await _baService.MultiplePostWO(previousWorkdays);
            var procdutionpost = await _woService.ProductionPlanWoPost(previousWorkdays);
            return Ok(procdutionpost);
        }

        [HttpPost]
        public async Task<IActionResult> ProductionPlanPost(ProductionPlan_WoVM production)
        {
            List<ProductionPlan_WoVM> productions = new List<ProductionPlan_WoVM>();
            if (production.PartType == 1)
            {
                production.Parentlevel = 'N';
            }
            else
            {
                var mpBOM = await _masterService.BOMS(production.PartId.ToString());
                if (mpBOM != null && mpBOM.Any())
                {
                    foreach (var bom in mpBOM)
                    {
                        var assy = await _masterService.GetManufPart((int)bom.BOMPartId);
                        if (assy != null)
                        {
                            production.Parentlevel = 'Y';
                        }
                        else
                        {
                            production.Parentlevel = 'N';
                        }
                    }
                }
                else
                {
                    production.Parentlevel = 'Y';
                }
            }
            productions.Add(production);
            var procdutionpost = await _woService.ProductionPlanWoPost(productions);
            return Ok(procdutionpost);
        }

        [HttpGet]
        public async Task<IActionResult> CalculateWOQuantity(string dispatchStartDate, string soCompletionDate, int balanceToManufacture, string dispatchOption)
        {
            var dispatchStartDt = DateTime.Parse(dispatchStartDate);
            var soCompletionDt = DateTime.Parse(soCompletionDate);

            var workdetails = await _plantService.GetPlantWD(13);
            var holidaylist = await _plantService.GetHolidays(13);
            string weekOff1 = workdetails.WeeklyOff1;
            string weekOff2 = workdetails.WeeklyOff2;

            int workDays = 0;

            for (var date = dispatchStartDt; date <= soCompletionDt; date = date.AddDays(1))
            {
                // Check if the day is a work day
                if (IsWorkDay(date, holidaylist, weekOff1, weekOff2))
                {
                    workDays++;
                }
            }

            int noOfWeeks = (int)Math.Ceiling((double)workDays / 7); // calculate number of weeks
            int noOfMonths = (int)Math.Ceiling((double)workDays / 30); // calculate number of months

            List<WorkOrdersVM> woDetails = new List<WorkOrdersVM>();

            switch (dispatchOption)
            {
                case "Daily":
                    int workDaysAdjusted = 0;
                    DateTime tempDate = dispatchStartDt.AddDays(1);
                    while (workDaysAdjusted < workDays)
                    {
                        if (!IsNonWorkingDay(tempDate, weekOff1, weekOff2, holidaylist))
                        {
                            workDaysAdjusted++;
                            WorkOrdersVM dailywo = new WorkOrdersVM
                            {
                                CalcWOQty = balanceToManufacture / workDays,
                                PlanCompletionDate = tempDate
                            };
                            woDetails.Add(dailywo);
                        }
                        tempDate = tempDate.AddDays(1);
                    }
                    break;
                case "Weekly":
                    //if (workDays > 22)
                    //{
                    int noOfWeeksAdjusted = 0;
                    tempDate = dispatchStartDt.AddDays(7);
                    while (noOfWeeksAdjusted < noOfWeeks)
                    {
                        int weeklyWoQuantity = balanceToManufacture / noOfWeeks;
                        while (!IsWorkDay(tempDate, holidaylist, weekOff1, weekOff2))
                        {
                            tempDate = tempDate.AddDays(1);
                        }
                        WorkOrdersVM wo = new WorkOrdersVM
                        {
                            CalcWOQty = weeklyWoQuantity,
                            PlanCompletionDate = tempDate
                        };
                        woDetails.Add(wo);
                        tempDate = tempDate.AddDays(7);
                        noOfWeeksAdjusted++;
                    }
                    //}
                    //else
                    //{
                    //    return BadRequest("Error: Number of work days is less than 22. Please use Manual Multiple selection.");
                    //}
                    break;
                case "Monthly":
                    if (workDays > 95)
                    {
                        int noOfMonthsAdjusted = 0;
                        tempDate = dispatchStartDt.AddMonths(1);
                        while (noOfMonthsAdjusted < noOfMonths)
                        {
                            int monthlyWoQuantity = balanceToManufacture / noOfMonths;

                            while (!IsWorkDay(tempDate, holidaylist, weekOff1, weekOff2))
                            {
                                tempDate = tempDate.AddDays(1);
                            }
                            WorkOrdersVM monthlywo = new WorkOrdersVM
                            {
                                CalcWOQty = monthlyWoQuantity,
                                PlanCompletionDate = tempDate
                            };
                            woDetails.Add(monthlywo);
                            tempDate = tempDate.AddMonths(1);
                            noOfMonthsAdjusted++;
                        }
                    }
                    else
                    {
                        return BadRequest("Error: Number of work days is less than 95. Please use Manual Multiple selection.");
                    }
                    break;
                default:
                    return BadRequest("Error: Invalid dispatch option.");
            }

            return Ok(woDetails);
        }

        private bool IsWorkDay(DateTime date, IEnumerable<HolidayVM> holidaylist, string weekOff1, string weekOff2)
        {
            // Check if the day is a holiday
            if (holidaylist.Any(h => h.HolidayDate == date))
            {
                return false;
            }

            // Check if the day is a weekly off
            var dayOfWeek = date.DayOfWeek.ToString();
            if (dayOfWeek == weekOff1 || dayOfWeek == weekOff2)
            {
                return false;
            }

            // If none of the above conditions are true, it's a work day
            return true;
        }

        bool IsNonWorkingDay(DateTime date, string weekOff1, string weekOff2, IEnumerable<HolidayVM> holidaylist)
        {
            DayOfWeek day = date.DayOfWeek;
            string dayName = date.DayOfWeek.ToString();

            //if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            //{
            //    return true; // Weekend
            //}
            if (dayName == weekOff1 || dayName == weekOff2)
            {
                return true; // Weekoff1 or Weekoff2
            }
            else if (holidaylist.Any(h => h.HolidayDate == date.Date))
            {
                return true; // Holiday
            }
            return false; // Working day
        }
    }
}
