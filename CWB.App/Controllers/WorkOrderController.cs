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
    [Authorize(Roles =Roles.ADMIN)]
    public class WorkOrderController : Controller
    {
        private readonly ILogger<WorkOrderController> _logger;
        private readonly IWOService _woService;
        private readonly IBAService _baService;
        private readonly IRoutingService _routingService;
        private readonly IMastersServices _masterService;
        private readonly IPlantService _plantService;
        public WorkOrderController(ILogger<WorkOrderController> logger,IWOService wOService, IBAService baService, IRoutingService routingService, IMastersServices masterServices,IPlantService plantService)
        {
            _logger =logger;
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
                    }
                }
            }
            return Ok(workOrders);
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

            //switch (dispatchOption)
            //{
            //    case "Daily":
            //        int dailyWoQuantity = balanceToManufacture / workDays;
            //        for (int i = 0; i < workDays; i++)
            //        {
            //            //woDetails.Add((dailyWoQuantity, dispatchStartDt.AddDays(i + 1)));
            //            WorkOrdersVM dailywo = new WorkOrdersVM
            //            {
            //                CalcWOQty=dailyWoQuantity,
            //                PlanCompletionDate=dispatchStartDt.AddDays(i+1)
            //            };
            //            woDetails.Add(dailywo);
            //        }
            //        break;
            //    case "Weekly":
            //        if (workDays > 22)
            //        {
            //            int weeklyWoQuantity = balanceToManufacture / noOfWeeks;
            //            for (int i = 0; i < noOfWeeks; i++)
            //            {
            //                WorkOrdersVM wo=new WorkOrdersVM
            //                {
            //                    CalcWOQty=weeklyWoQuantity,
            //                    PlanCompletionDate = dispatchStartDt.AddDays(i * 7 + 7)
            //                };
            //                woDetails.Add(wo);
            //            }
            //        }
            //        else
            //        {
            //            return BadRequest("Error: Number of work days is less than 22. Please use Manual Multiple selection.");
            //        }
            //        break;
            //    case "Monthly":
            //        if (workDays > 95)
            //        {
            //            int monthlyWoQuantity = balanceToManufacture / noOfMonths;
            //            for (int i = 0; i < noOfMonths; i++)
            //            {
            //                //woDetails.Add((monthlyWoQuantity, dispatchStartDt.AddMonths(i + 1)));
            //                WorkOrdersVM monthlywo = new WorkOrdersVM
            //                {
            //                    CalcWOQty = monthlyWoQuantity,
            //                    PlanCompletionDate = dispatchStartDt.AddMonths(i + 1)
            //                };
            //                woDetails.Add(monthlywo);
            //            }
            //        }
            //        else
            //        {
            //            return BadRequest("Error: Number of work days is less than 95. Please use Manual Multiple selection.");
            //        }
            //        break;
            //    default:
            //        return BadRequest("Error: Invalid dispatch option.");
            //}
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
                    if (workDays > 22)
                    {
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
                    }
                    else
                    {
                        return BadRequest("Error: Number of work days is less than 22. Please use Manual Multiple selection.");
                    }
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
