using CWB.App.Models.Contacts;
using CWB.App.Models.Routing;
using CWB.App.Models.Routings;
using CWB.App.Services.Masters;
using CWB.App.Services.Routings;
using CWB.Constants.UserIdentity;
using CWB.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.App.Controllers
{
    [Authorize(Roles = Roles.ADMIN)]
    public class RoutingsController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IRoutingService _routingService;
        private readonly IMastersServices _mastersServices;
        private readonly IMachineService _machineService;

        public RoutingsController(ILoggerManager logger, IMachineService machineService, IRoutingService routingService,IMastersServices mastersServices)
        {
            _logger = logger;
            _routingService = routingService;
            _mastersServices = mastersServices;
            _machineService = machineService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RoutingListItems()
        {
            var result = await _routingService.GetRoutingListItems();
            return Json(result);
        }
        //GetRoutingListItmes

        [HttpPost]
        public async Task<IActionResult> AddNewRouting(RoutingVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.Routing(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AltRouting(RoutingVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.AltRouting(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRouting(int routingId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.DeleteRouting(routingId);
            return Ok(result);
        }

        //preferredsubcon
        [HttpGet]
        public async Task<IActionResult> PreferredSubCon(int subConDetailsId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.PreferredSubCon(subConDetailsId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PreferredRouting(RoutingVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.PreferredRouting(model);
            return Ok(result);
        }


        public async Task<IActionResult> RoutingDetails(int manufPartId,string partType)
        {
            var result = await _routingService.GetRoutingListItems();
            var query = from litem in result
                        where litem.ManufacturedPartId == manufPartId
                        select litem;
            RoutingListItemVM routingListItemVM = query.FirstOrDefault();
            if(routingListItemVM == null)
            {
                routingListItemVM = new RoutingListItemVM();
                routingListItemVM.MasterPartType = partType;
                routingListItemVM.RoutingVMs = new List<RoutingVM>();
            }
            else
            {
                var resultList = await _routingService.Routings(manufPartId);
                routingListItemVM.MasterPartType = partType;
                routingListItemVM.RoutingVMs = resultList.ToList();
            }
            return View(routingListItemVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAltRouting(RoutingVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.Routing(model);
            return Ok(result);
        }

        public IActionResult AddNextStep()
        {
            return Ok("Ok");
        }

        [HttpPost]
        public async Task<IActionResult> SaveStep(RoutingStepVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.RoutingStep(model);
            return Ok(result);
        }

       
        public async Task<IActionResult> DelStep(int stepId)
        {
            var result = await _routingService.DeleteStep(stepId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBomToAssembly(RoutingStepPartVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.RoutingStepPart(model);
            return Ok(result);
        }

        public async Task<IActionResult> RoutingSteps(int routingId)
        {
            var result = await _routingService.RoutingSteps(routingId);
            return Ok(result);
        }

        public async Task<IActionResult> StepParts(int stepId)
        {
            var result = await _routingService.StepParts(stepId);
            return Ok(result);
        }


        public async Task<IActionResult> BOMs(int manufId, int stepId)
        {
            var boms = await _mastersServices.BOMS(""+manufId);
            var manfsps = await _routingService.StepPartsByManufId(manufId);
            var stepparts = await _routingService.StepParts(stepId);

            var query = from bom in boms
                        select new StepBOMVM
                        {
                            BOMPartNo = bom.BOMPartNo,
                            BOMManufPartId = bom.BOMManufPartId,
                            BOMPartId = bom.BOMPartId,
                            BOMPartDesc = bom.BOMPartDesc,
                            MPBOMId = bom.MPBOMId,
                            Quantity = bom.Quantity,
                            QuantityUsed = 0,
                            BalanceQuantity = bom.Quantity,
                            StepPartId = -1,
                            RoutingStepId = -1
                        };
            List<StepBOMVM> lst = query.ToList();
            //Calculate balance quantity for boms
            try
            {
                foreach (RoutingStepPartVM sp in manfsps)
                {
                    foreach (StepBOMVM spbom in lst)
                    {
                        if (spbom != null && sp != null)
                        {
                            if (spbom.MPBOMId == sp.BOMId)
                            {
                                spbom.QuantityUsed += sp.QuantityAssembly;
                                spbom.BalanceQuantity = spbom.Quantity - spbom.QuantityUsed;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                string msg = ex.InnerException.Message;
                string src = ex.InnerException.Source;
            }
            //reset quantity used on BOM... just for display purpoo
            foreach (StepBOMVM spbom in lst)
            {
                spbom.QuantityUsed = 0;
            }
            List<StepBOMVM> list1 = new List<StepBOMVM> ();
            foreach (RoutingStepPartVM sp in stepparts)
            {
                foreach (StepBOMVM bom in lst)
                {
                    if (bom.MPBOMId == sp.BOMId)
                    {
                        StepBOMVM obj = new StepBOMVM {
                            BOMPartNo = bom.BOMPartNo,
                            BOMManufPartId = bom.BOMManufPartId,
                            BOMPartId = bom.BOMPartId,
                            BOMPartDesc = bom.BOMPartDesc,
                            MPBOMId = bom.MPBOMId,
                            Quantity = 0,
                            QuantityUsed = sp.QuantityAssembly,
                            BalanceQuantity = 0,
                            StepPartId = (int)sp.StepPartId,
                            RoutingStepId = (int)sp.RoutingStepId
                        };
                        list1.Add(obj);
                        break;
                    }
                }
            }
            lst.AddRange(list1);
            return Ok(lst);
        }

        public async Task<IActionResult> StepBOMs(int stepId)
        {
            var result = await _routingService.StepParts(stepId);
            return Ok(result);
        }



        public IActionResult   Routings(int manufPartId)
        {
            return Ok("hello");
        }



        [HttpPost]
        public async Task<IActionResult> SaveStepSupplier(RoutingStepSupplierVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.RoutingStepSupplier(model);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> SaveStepMachine(RoutingStepMachineVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.RoutingStepMachine(model);
            return Ok(result);
        }

        public async Task<IActionResult> PreferredStepMachine(string routingStepId, string routingStepMachineId, int maxMachineCount)
        {
            var result = await _routingService.PreferredStepMachine(routingStepId, routingStepMachineId,maxMachineCount);
            return Ok(result);
        }

        public async Task<IActionResult> StepSuppliers(int stepId)
        {
            var companies = await _mastersServices.GetCompanies();
            var result = await _routingService.StepSuppliers(stepId);
            foreach (RoutingStepSupplierVM obj in result)
            {
                foreach (ContactsVM mobj in companies)
                {
                    if (obj.SupplierId == mobj.CompanyId)
                    {
                        obj.Name = mobj.CompanyName;
                    }
                }
            }
            return Ok(result);
        }
        

        public async Task<IActionResult> StepMachines(int stepId)
        {
            var machines = await _machineService.GetMachinesList();
            var result = await _routingService.StepMachines(stepId);
            foreach (RoutingStepMachineVM obj in result)
            {
                foreach (Models.Machine.MachineListVM mobj in machines)
                {
                    if(obj.MachineId == mobj.MachineId)
                    {
                        obj.Name = mobj.Name;
                    }
                }
            }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Locations()
        {
            List<LocationVM> locations = new List<LocationVM>();
            locations.Add(new LocationVM { Id=1,Name= "Inhouse" });
            locations.Add(new LocationVM { Id = 2, Name = "SubCon" });
            locations.Add(new LocationVM { Id = 3, Name = "Company" });
            return Ok(locations);
        }


        public async Task<IActionResult> DeleteStep(int stepId)
        {
            var machines = await _machineService.GetMachinesList();
            var result = await _routingService.DeleteStep(stepId);
            return Ok(result);
        }

        public async Task<IActionResult> DeleteMachine(int stepId,int machineId)
        {
            var result = await _routingService.DeleteMachine(stepId,machineId);
            return Ok(result);
        }
        public async Task<IActionResult> DeleteStepSupplier(int stepId, int supplierId)
        {
            var result = await _routingService.DeleteSupplier(stepId,supplierId);
            return Ok(result);
        }





        public async Task<IActionResult> SubCons(int stepId)
        {
            var companies = await _mastersServices.GetCompanies();
            var subconwss = await _routingService.SubConWSS(stepId,-1);
            var result = await _routingService.SubCons(stepId);
            foreach (SubConDetailsVM obj in result)
            {
                obj.StrPreferredSubCon = (obj.PreferredSubcon==1)?"Yes":"";
            }

            foreach (SubConDetailsVM obj in result)
            {
                foreach (ContactsVM mobj in companies)
                {
                    if (obj.SupplierId == mobj.CompanyId)
                    {
                        obj.Company = mobj.CompanyName;
                    }
                }
            }
            foreach (SubConDetailsVM obj in result)
            {
                foreach (SubConWorkStepDetailsVM mobj in subconwss)
                {
                    if (obj.SubConDetailsId == mobj.SubConDetailsId)
                    {
                        obj.NoOfOperations++;
                    }
                }
            }
            return Ok(result);
        }

        public async Task<IActionResult> AllSubConWSS(int stepId)
        {
            return await SubConWSS(stepId, -1);
        }
        public async Task<IActionResult> SubConWSS(int stepId,int subConDetailsId)
        {
            var companies = await _mastersServices.GetCompanies();
            var result = await _routingService.SubConWSS(stepId,subConDetailsId);
            /*foreach (SubConDetailsVM obj in result)
            {
                foreach (ContactsVM mobj in companies)
                {
                    if (obj.SupplierId == mobj.CompanyId)
                    {
                        obj.Company = mobj.CompanyName;
                    }
                }
            }*/
            return Ok(result);
        }

        
        public async Task<IActionResult> DeleteSubConDetails(int stepId, int subConDetailsId)
        {
            var result = await _routingService.DeleteSubCon(stepId, subConDetailsId);
            return Ok(result);
        }

        //SubCons/SubConWSS/DeleteSubConDetails/DeleteSubConWS
        public async Task<IActionResult> DeleteSubConWS(int stepId, int subConWSDetailsId)
        {
            var result = await _routingService.DeleteSubConWS(stepId, subConWSDetailsId);
            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddSubCon(SubConDetailsVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.SubConDetails(model);
            return Ok(result);
        }
        //SubCons/SubConWSS/DeleteSubConDetails/DeleteSubConWS/AddSubCon//AddSubConWS
        [HttpPost]
        public async Task<IActionResult> AddSubConWS(SubConWorkStepDetailsVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.SubConWSDetails(model);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteWS(int subConWSId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.DeleteWS(subConWSId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteStepPart(int stepId,int stepPartId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _routingService.DeleteStepPart(stepId, stepPartId);
            return Ok(result);
        }




        //public const string DeleteSubConDetails = Base + "/deletesubcondetails/{stepId}/{subConDetailsId}";
        //public const string DeleteSubWSConDetails = Base + "/deletesubconworkstepdetails/{stepId}/{subConWSDetailsId}";

    }
}
