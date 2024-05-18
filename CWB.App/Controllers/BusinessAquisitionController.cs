using CWB.App.Models.BusinessProcesses;
using CWB.App.Models.ItemMaster;
using CWB.App.Services.BusinessProcesses;
using CWB.App.Services.Masters;
using CWB.Constants.UserIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.App.Controllers
{

    /**
     *    public const string GetPOLogs = Base + "/getpologs/{tenantId}";
            public const string GetSalesOrders = Base + "/getsalesorders/{tenantId}/{customerOderId}";
            public const string GetCustomerOrders = Base + "/getcustomerorders/{tenantId}";
            public const string GetSchedules = Base + "/getdeliveryschedules/{tenantId}/{customerOrderId}";
            public const string HelloWorld = Base + "/helloworld/{tenantId}";

            public const string PostSalesOrder = Base + "/salesorder";
            public const string PostCustomerOrder = Base + "/custorder";
            public const string PostDeliverySchedule = Base + "/deliveryschedule";
            public const string PostOrderStatus = Base + "/orderstatus";
            public const string PostPOLog = Base + "/polog";

            public const string RemoveSalesOrder = Base + "/removesalesorder/{tenantId}/{salesOrderId}";
            public const string RemoveCustomerOder = Base + "/removecustomerorder/{tenantId}/{customerOrderId}";
            public const string RemoveDeliverSchedule = Base + "/removedeliveryschedule/{tenantId}/{scheduleId}";
            public const string RemoveOrderStatus = Base + "/removeorderstatus/{tenantId}/{orderStatusId}";
     */

    [Authorize(Roles = Roles.ADMIN)]
    public class BusinessAquisitionController : Controller
    {
        private readonly ILogger<BusinessAquisitionController> _logger;
        private readonly IBAService _baService;
        private readonly IMastersServices _masterService;
        public BusinessAquisitionController(ILogger<BusinessAquisitionController> logger, IBAService baService,IMastersServices masterServices)
        {
            _logger = logger;
            _baService = baService;
            _masterService = masterServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderEntry()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPOLogs(long customerOrderId)
        {
            var pologs = await _baService.GetPOLogs(customerOrderId);
            return Ok(pologs);

        }
        [HttpGet]
        public async Task<string> HelloWorld()
        {
            return await _baService.HelloWorld();
        }

        [HttpGet]
        public async Task<IActionResult> GetSalesOrders(long customerOrderId,long partId=0)
        {
            var salesorders = await _baService.GetSalesOrders(customerOrderId);
            var masterparts = await _masterService.ItemMasterParts();
            foreach(SalesOrderVM sovm in salesorders)
            {
                foreach(ItemMasterPartVM impvm in masterparts)
                {
                    if(sovm.PartId == impvm.PartId)
                    {
                        sovm.PartNo = impvm.PartNo;
                    }
                }
            }

            return Ok(salesorders);

        }

        [HttpGet]
        public async Task<IActionResult> GetCustOrders()
        {
            var custOrders = await _baService.GetCustomerOrders();
            return Ok(custOrders);
        }


        [HttpGet]
        public async Task<IActionResult> GetPOLines(long customerOrderId)
        {
            var salesorders = await _baService.GetSalesOrders(customerOrderId);
            var masterparts = await _masterService.ItemMasterParts();
            List<POLineVM> pOLines = new List<POLineVM>();
            foreach (SalesOrderVM sovm in salesorders)
            {
                foreach (ItemMasterPartVM impvm in masterparts)
                {
                    if (sovm.PartId == impvm.PartId)
                    {
                        sovm.PartNo = impvm.PartNo;
                        sovm.PartId = impvm.PartId.GetValueOrDefault();
                    }
                }
            }
            foreach (SalesOrderVM sovm in salesorders)
            {
                if (pOLines.Count() == 0)
                {
                    POLineVM polineVM = new POLineVM();
                    polineVM.PartNo = sovm.PartNo;
                    polineVM.PartId = sovm.PartId;
                    polineVM.TotalQty = sovm.RequiredQuantity;
                    polineVM.Status = sovm.Status;
                    polineVM.Matl = sovm.Matl;
                    polineVM.Hold = sovm.Hold;
                    polineVM.Plan = sovm.Plan;
                    polineVM.Matl = sovm.Matl;
                    polineVM.WIP = sovm.WIP;
                    polineVM.NumSalesOrder = 1;
                    pOLines.Add(polineVM);
                }
                else
                {
                    bool foundPOLine = false;
                    foreach (POLineVM povm in pOLines)
                    {
                        if (sovm.PartNo == povm.PartNo)
                        {
                            povm.TotalQty += sovm.RequiredQuantity;
                            foundPOLine = true;
                            povm.NumSalesOrder += 1;
                        }
                    }
                    if (foundPOLine) { }
                    else
                    {
                        POLineVM polineVM = new POLineVM();
                        polineVM.PartNo = sovm.PartNo;
                        polineVM.PartId = sovm.PartId;
                        polineVM.TotalQty = sovm.RequiredQuantity;
                        polineVM.Status = sovm.Status;
                        polineVM.Matl = sovm.Matl;
                        polineVM.Hold = sovm.Hold;
                        polineVM.Plan = sovm.Plan;
                        polineVM.Matl = sovm.Matl;
                        polineVM.WIP = sovm.WIP;
                        polineVM.NumSalesOrder = 1;
                        pOLines.Add(polineVM);
                    }
                }
            }
            return Ok(pOLines);
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedules(long customerOrderId)
        {
            var schedules = await _baService.GetSchedules(customerOrderId);
            var masterparts = await _masterService.ItemMasterParts();
            foreach (DeliveryScheduleVM sovm in schedules)
            {
                foreach (ItemMasterPartVM impvm in masterparts)
                {
                    if (sovm.DSPartId == impvm.PartId)
                    {
                        sovm.PartNo = impvm.PartNo;
                    }
                }
            }
            return Ok(schedules);
        }

        [HttpGet]
        public async Task<IActionResult> GetSOAggregate(long customerOrderId)
        {
            var pologs = await _baService.GetSOAggregate(customerOrderId);
            return Ok(pologs);

        }

        [HttpPost]
        public async Task<IActionResult> POLog(POLogVM pOLogVM)
        {
            var salesOrder = await _baService.PostPOLog(pOLogVM);
            return Ok(salesOrder);
        }
        [HttpPost]
        public async Task<IActionResult> SOLog(POLogVM pOLogVM)
        {
            var salesOrder = await _baService.PostSOLog(pOLogVM);
            return Ok(salesOrder);
        }

        [HttpPost]
        public async Task<IActionResult> SalesOrder(SalesOrderVM salesOrderVM)
        {
            var salesOrder = await _baService.PostSalesOrder(salesOrderVM);
            return Ok(salesOrder);
        }

        [HttpPost]
        public async Task<IActionResult> CustomerOrder(CustomerOrderVM customerOrderVM)
        {
            var customerOrder = await _baService.PostCustomerOrder(customerOrderVM);
            return Ok(customerOrder);
        }

        [HttpPost]
        public async Task<IActionResult> DeliverySchedule(DeliveryScheduleVM deliveryScheduleVM)
        {
            var deliverySchedule = await _baService.PostDeliverySchedule(deliveryScheduleVM);
            return Ok(deliverySchedule);
        }

        [HttpPost]
        public async Task<IActionResult> SOAggregate(SOAggregateVM sOAggregateVM)
        {
            var deliverySchedule = await _baService.PostSOAggregate(sOAggregateVM);
            return Ok(deliverySchedule);
        }


        [HttpGet]
        public async Task<bool> RemoveCustomerOrder(long cutomerOrderId)
        {
            return await _baService.RemoveCustomerOder(cutomerOrderId);
        }
        [HttpGet]
        public async Task<bool> RemoveSalesOrder(long salesOrderId)
        {
            return await _baService.RemoveSalesOrder(salesOrderId);
        }
        [HttpGet]
        public async Task<bool> RemoveSchedule(long scheduleId)
        {
            return await _baService.RemoveDeliverySchedule(scheduleId);
        }

        [HttpGet]
        public async Task<bool> AddSalesOrders(long customerOrderId)
        {
            return await _baService.AddSalesOrders(customerOrderId);
        }

    }
}
