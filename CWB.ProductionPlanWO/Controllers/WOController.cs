using CWB.CommonUtils.Common;
using CWB.Constants.UserIdentity;
using CWB.Logging;
using CWB.ProductionPlanWO.Services;
using CWB.ProductionPlanWO.Utils;
using CWB.ProductionPlanWO.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.ProductionPlanWO.Controllers
{
    [ApiController]
    [Authorize]
    public class WOController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IWOService _woSerivce;
        public WOController(ILoggerManager logger, IWOService woSerivce)
        {
            _logger = logger;
            _woSerivce = woSerivce;
        }
        [HttpGet]
        [Route(ApiRoutes.WO.HelloWorld)]
        [Produces(AppContentTypes.ContentType, Type = typeof(string))]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<string> HelloWorld()
        {
            var pologs = _woSerivce.HelloWorld();
            return pologs;
        }

        [HttpPost]
        [Route(ApiRoutes.WO.PostWorkOrder)]
        [Produces(AppContentTypes.ContentType,Type=typeof(WorkOrdersVM))]
        public async Task<IActionResult> PostWorkOrder([FromBody]WorkOrdersVM workOrdersVM)
        {
            var result = await _woSerivce.WorkOrder(workOrdersVM);
            return Ok(result);
        }

        [HttpPost]
        [Route(ApiRoutes.WO.PostMultipleWorkOrder)]
        [Produces(AppContentTypes.ContentType, Type = typeof(WorkOrdersVM))]
        public async Task<IActionResult> PostMultipleWorkOrder([FromBody] List<WorkOrdersVM> workOrdersVM)
        {
            var result = await _woSerivce.MultipleWorkOrder(workOrdersVM);
            return Ok(result);
        }

        [HttpPost]
        [Route(ApiRoutes.WO.PostWOSORel)]
        [Produces(AppContentTypes.ContentType, Type = typeof(WOSOVM))]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> PostWOSORel([FromBody] List<WOSOVM> wOSOVMs)
        {
            var woso = await _woSerivce.PostWOSO(wOSOVMs);
            return Ok(woso);
        }

        [HttpGet]
        [Route(ApiRoutes.WO.AllWorkOrders)]
        [Produces(AppContentTypes.ContentType,Type=typeof(List<WorkOrdersVM>))]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> AllWorkOrders(long tenantId)
        {
            var allwo = await _woSerivce.AllWorkOrders(tenantId);
            return Ok(allwo);
        }

        [HttpGet]
        [Route(ApiRoutes.WO.GetSingleWorkOrder)]
        [Produces(AppContentTypes.ContentType,Type=typeof(WorkOrdersVM))]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetSingleWO(long Id,long tenantId)
        {
            WorkOrdersVM singleWO = await _woSerivce.GetSingleWO(Id, tenantId);
            return Ok(singleWO);
        }

        [HttpGet]
        [Route(ApiRoutes.WO.GetSoWo)]
        [Produces(AppContentTypes.ContentType,Type =typeof(List<WOSOVM>))]
        [Authorize(Roles=Roles.ADMIN)]
        public async Task<IActionResult> GetSoWo(long workOrderId)
        {
            var so = await _woSerivce.GetSoWo(workOrderId);
            return Ok(so);
        }
    }
}
