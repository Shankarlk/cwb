using CWB.App.AppUtils;
using CWB.App.Models.EmployeeMaster;
using CWB.App.Services.CompanySettings;
using CWB.App.Services.EmployeeMaster;
using CWB.App.Services.Masters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CWB.App.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMastersServices _mastersService;
        private readonly IEmployeeService _employeeService;
        private readonly IPlantService _plantService;
        private readonly IDepartmentService _deptService;
        public EmployeeController(ILogger<EmployeeController> logger, IMastersServices mastersService,IEmployeeService employeeService,
            IPlantService plantService,IDepartmentService departmentService)
        {
            _logger = logger;
            _mastersService = mastersService;
            _employeeService = employeeService;
            _plantService = plantService;
            _deptService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal userClaim = HttpContext.User;
            string fullName = AppUtil.GetUsername(userClaim);
            var emp = await _employeeService.GetAllEmployee();
            var e = emp.Where(e => e.UserName == fullName).FirstOrDefault();
            if (e != null)
            {
                var org = await _employeeService.GetAllOrgChart();
                var designation = await _employeeService.GetAllUilist();
                var sorg = org.Where(r => r.Employee_Id == e.Employee_ID).FirstOrDefault();
                var role = await _employeeService.GetAllRoleList();
                if (sorg != null)
                {
                    var roleui = await _employeeService.GetAllRoleUiList();
                    var result = roleui.Where(r => r.RoleId == sorg.Role_NameId).ToList();
                    foreach (var item in result)
                    {
                        var d = designation.Where(u => u.UiListId == item.Ui_Id).FirstOrDefault();
                        var r = role.Where(u => u.Role_ListId == item.RoleId).FirstOrDefault();
                        item.RoleName = r.Role_Desc;
                        if (d != null)
                        {
                            if (d.UI_Part_linked_to == 0)
                            {
                                item.UiLevel = d.UI_Name_Label;
                                item.Menu1 = d.UI_Name_Label;
                            }
                            else
                            {
                                var menu2 = designation.Where(m => m.UiListId == d.UI_Part_linked_to).FirstOrDefault();
                                if (menu2.UI_Part_linked_to == 0)
                                {
                                    item.UiLevel = menu2.UI_Name_Label + "+" + d.UI_Name_Label;
                                    item.Menu2 = d.UI_Name_Label;
                                    item.Menu1 = menu2.UI_Name_Label;
                                }
                                else
                                {
                                    var menu3 = designation.Where(m => m.UiListId == menu2.UI_Part_linked_to).FirstOrDefault();
                                    if (menu3.UI_Part_linked_to == 0)
                                    {
                                        item.UiLevel = menu3.UI_Name_Label + "+" + menu2.UI_Name_Label + "+" + d.UI_Name_Label;
                                        item.Menu1 = menu3.UI_Name_Label;
                                        item.Menu2 = menu2.UI_Name_Label;
                                        item.Menu3 = d.UI_Name_Label;
                                    }
                                    else
                                    {
                                        var menu4 = designation.Where(m => m.UiListId == menu3.UI_Part_linked_to).FirstOrDefault();
                                        if (menu4.UI_Part_linked_to == 0)
                                        {
                                            item.UiLevel = menu4.UI_Name_Label + "+" + menu3.UI_Name_Label + "+" + menu2.UI_Name_Label + "+" + d.UI_Name_Label;
                                            item.Menu1 = menu4.UI_Name_Label;
                                            item.Menu2 = menu3.UI_Name_Label;
                                            item.Menu3 = menu2.UI_Name_Label;
                                            item.Menu4 = d.UI_Name_Label;
                                        }
                                        else
                                        {
                                            var menu5 = designation.Where(m => m.UiListId == menu4.UI_Part_linked_to).FirstOrDefault();
                                            if (menu5.UI_Part_linked_to == 0)
                                            {
                                                item.UiLevel = menu5.UI_Name_Label + "+" + menu4.UI_Name_Label + "+" + menu3.UI_Name_Label + "+" + menu2.UI_Name_Label + "+" + d.UI_Name_Label;
                                                item.Menu1 = menu5.UI_Name_Label;
                                                item.Menu2 = menu4.UI_Name_Label;
                                                item.Menu3 = menu3.UI_Name_Label;
                                                item.Menu4 = menu2.UI_Name_Label;
                                                item.Menu5 = d.UI_Name_Label;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (item.PermissionId == 1)
                        {
                            item.View_Allowed = "N";
                            item.Add_Edit_Allowed = "N";
                            item.Delete_Allowed = "N";
                            item.Approval_Allowed = "N";
                        }
                        else if (item.PermissionId == 2)
                        {
                            item.View_Allowed = "Y";
                            item.Add_Edit_Allowed = "N";
                            item.Delete_Allowed = "N";
                            item.Approval_Allowed = "N";
                        }
                        else if (item.PermissionId == 3)
                        {
                            item.View_Allowed = "Y";
                            item.Add_Edit_Allowed = "Y";
                            item.Delete_Allowed = "N";
                            item.Approval_Allowed = "N";
                        }
                        else if (item.PermissionId == 4)
                        {
                            item.View_Allowed = "Y";
                            item.Add_Edit_Allowed = "Y";
                            item.Delete_Allowed = "Y";
                            item.Approval_Allowed = "N";
                        }
                        else if (item.PermissionId == 5)
                        {
                            item.View_Allowed = "Y";
                            item.Add_Edit_Allowed = "Y";
                            item.Delete_Allowed = "Y";
                            item.Approval_Allowed = "Y";
                        }
                    }
                    var permissionresult = result;

                    ViewData["PermissionResult"] = permissionresult;
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var designation = await _employeeService.GetAllEmployee();
            var loc = await _plantService.GetPlants();
            foreach (var item in designation)
            {
                item.DateOfJoinStr = item.Date_Of_Joining.ToString("d");
                var l = loc.Where(l => l.PlantId == item.Plant_Id).FirstOrDefault();
                item.Location = l.Name;
            }
            return Ok(designation);
        }
        [HttpGet]
        public async Task<IActionResult> GetUnique(string empNo)
        {
            var result = await _employeeService.GetAllEmployee();
            bool exists = result.Any(e => e.Employee_No == empNo);
            return Json(!exists);
        }
        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeVM model)
        {
            var result = await _employeeService.PostEmployee(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> DelEmployee(long designationId)
        {
            var result = await _employeeService.DelEmployee(designationId);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUilist()
        {
            var designation = await _employeeService.GetAllUilist();
            foreach (var item in designation)
            {
                if (item.UI_Part_linked_to == 0)
                {
                    item.Menu1 = item.UI_Name_Label;
                }
                else
                {
                    var menu2 = designation.Where(m => m.UiListId == item.UI_Part_linked_to).FirstOrDefault();
                    if(menu2.UI_Part_linked_to == 0)
                    {
                        item.Menu2 = item.UI_Name_Label;
                        item.Menu1 = menu2.UI_Name_Label;
                    }
                    else
                    {
                        var menu3 = designation.Where(m => m.UiListId == menu2.UI_Part_linked_to).FirstOrDefault();
                        if (menu3.UI_Part_linked_to == 0)
                        {
                            item.Menu1 = menu3.UI_Name_Label;
                            item.Menu2 = menu2.UI_Name_Label;
                            item.Menu3 = item.UI_Name_Label;
                        }
                        else
                        {
                            var menu4 = designation.Where(m => m.UiListId == menu3.UI_Part_linked_to).FirstOrDefault();
                            if (menu4.UI_Part_linked_to == 0)
                            {
                                item.Menu1 = menu4.UI_Name_Label;
                                item.Menu2 = menu3.UI_Name_Label;
                                item.Menu3 = menu2.UI_Name_Label;
                                item.Menu4 = item.UI_Name_Label;
                            }
                            else
                            {
                                var menu5 = designation.Where(m => m.UiListId == menu4.UI_Part_linked_to).FirstOrDefault();
                                if (menu5.UI_Part_linked_to == 0)
                                {
                                    item.Menu1 = menu5.UI_Name_Label;
                                    item.Menu2 = menu4.UI_Name_Label;
                                    item.Menu3 = menu3.UI_Name_Label;
                                    item.Menu4 = menu2.UI_Name_Label;
                                    item.Menu5 = item.UI_Name_Label;
                                }
                            }
                        }
                    }
                }
            }
            return Ok(designation);
        }

        [HttpGet]
        public async Task<IActionResult> GetUniqueUiName(string uiName)
        {
            var designation = await _employeeService.GetAllUilist();
            bool result = true;
            foreach (var item in designation)
            {
                if (item.UI_Name_Label == uiName)
                {
                    result = false;
                    return Ok(result);
                }
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostUilist(UiListVM model)
        {
            var designation = await _employeeService.GetAllUilist();
            if (model.UI_Part_linked_to == 0)
            {
                model.MenuLevelId = 1;
            }
            else
            {
                var menu2 = designation.Where(m => m.UiListId == model.UI_Part_linked_to).FirstOrDefault();
                if (menu2.UI_Part_linked_to == 0)
                {
                    model.MenuLevelId = 2;
                }
                else
                {
                    var menu3 = designation.Where(m => m.UiListId == menu2.UI_Part_linked_to).FirstOrDefault();
                    if (menu3.UI_Part_linked_to == 0)
                    {
                        model.MenuLevelId = 3;
                    }
                    else
                    {
                        var menu4 = designation.Where(m => m.UiListId == menu3.UI_Part_linked_to).FirstOrDefault();
                        if (menu4.UI_Part_linked_to == 0)
                        {
                            model.MenuLevelId = 4;
                        }
                        else
                        {
                            var menu5 = designation.Where(m => m.UiListId == menu4.UI_Part_linked_to).FirstOrDefault();
                            if (menu5.UI_Part_linked_to == 0)
                            {
                                model.MenuLevelId = 5;
                            }
                        }
                    }
                }
            }
            var result = await _employeeService.PostUilist(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> CheckUiList(long designationId)
        {
            var result = await _employeeService.GetAllEmplRoleUiList();
            bool r;
            if (result.Any())
            {
                foreach (var item in result)
                {
                    if (item.Ui_Id == designationId)
                    {
                        r = false;
                        return Json(r);
                    }
                }
            }
            else
            {
                var roleui = await _employeeService.GetAllRoleUiList();
                foreach (var item in roleui)
                {
                    if (item.Ui_Id == designationId)
                    {
                        r = false;
                        return Json(r);
                    }
                }
            }
            r = true;
            return Json(r);
        }
        [HttpGet]
        public async Task<IActionResult> DelUiList(long designationId)
        {
            var result = await _employeeService.DelUiList(designationId);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoleList()
        {
            var designation = await _employeeService.GetAllRoleList();
            var roleui = await _employeeService.GetAllRoleUiList();
            List<Role_ListVM> roles = new List<Role_ListVM>();
            foreach (var item in designation)
            {
                var r = roleui.Where(r => r.RoleId == item.Role_ListId).FirstOrDefault();
                if(r!=null)
                {
                    roles.Add(item);
                }
            }
            return Ok(roles);
        }
        [HttpGet]
        public async Task<IActionResult> GetUniqueRole(string roleName)
        {
            var designation = await _employeeService.GetAllRoleList();
            bool result = true;
            foreach (var item in designation)
            {
                if(item.Role_Desc== roleName)
                {
                    result = false;
                    return Ok(result);
                }
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostRolelist(Role_ListVM model)
        {
            var result = await _employeeService.PostRolelist(model);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrgChart()
        {
            var designation = await _employeeService.GetAllOrgChart();
            var loc = await _plantService.GetPlants();
            var dept = await _deptService.GetDepartments(1);
            var role = await _employeeService.GetAllRoleList();
            var employee = await _employeeService.GetAllEmployee();
            foreach (var item in designation)
            {
                item.Level = item.Level_No.ToString();
                var l = loc.Where(l => l.PlantId == item.Location_id).FirstOrDefault();
                var d = dept.Where(l => l.DepartmentId == item.Dept_ID).FirstOrDefault();
                var r = role.Where(l => l.Role_ListId == item.Role_NameId).FirstOrDefault();
                if (r != null)
                {
                    item.RoleName = r.Role_Desc;
                }
                //var o = designation.Where(l => l.Employee_Id == item.Reporting_to).FirstOrDefault();
                var e = employee.Where(l => l.Employee_ID == item.Employee_Id).FirstOrDefault();
                item.Location = l.Name;
                item.Department = d.Name;
                //item.Employee = e.Employee_name;
                //if(o != null)
                //{
                //    var em = employee.Where(l => l.Employee_ID == item.Reporting_to).FirstOrDefault();
                //    var rr = role.Where(l => l.Role_ListId == o.Role_NameId).FirstOrDefault();
                //    if (rr != null)
                //    {
                //        item.Reporting = em.Employee_name + " / " + rr.Role_Desc;
                //    }
                //}
            }
            var groupedDesignations = designation
   .GroupBy(d => d.Dept_ID)
   .Select(g =>
   {
       var firstItem = g.First();
       var roles = g.Where(d => d.Role_NameId != null)
                    .Select(d => role.FirstOrDefault(r => r.Role_ListId == d.Role_NameId)?.Role_Desc)
                    .Where(r => r != null);

       var roleIds = g.Select(d => d.Role_NameId).Where(id => id != null);
       var orgChartIds = g.Select(d => d.Org_ChartId).Where(id => id != null); 
       var lowestLevel = g.Where(d => d.Level_No > 0 && d.Level_No < 5)
                           .Select(d => d.Level_No)
                           .DefaultIfEmpty() // Handle case where no levels exist
                           .Min();

       firstItem.RoleName = string.Join(", ", roles);
       firstItem.RoleIds = string.Join(", ", roleIds);
       firstItem.OrgChartIds = string.Join(", ", orgChartIds);
       firstItem.Level = lowestLevel.ToString();

       return firstItem;
   })
   .ToList();

            return Ok(groupedDesignations);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrgChart()
        {
            var designation = await _employeeService.GetAllOrgChart();
            return Ok(designation);
        }
        [HttpPost]
        public async Task<IActionResult> PostOrgChart(Org_ChartVM model)
        {
            var result = await _employeeService.PostOrgChart(model);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> DelOrgChart(long designationId)
        {
            var result = await _employeeService.DelOrgChart(designationId);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPermission()
        {
            var designation = await _employeeService.GetAllPermission();
            return Ok(designation);
        }

        [HttpPost]
        public async Task<IActionResult> PostRoleUiList(Role_UI_ListVM model)
        {
            if (model.RoleId==0)
            {
                var org = await _employeeService.GetAllOrgChart();
                if (model.EmployeeId!=0)
                {
                    var sorg = org.Where(r => r.Dept_ID == model.DepartmentId).FirstOrDefault();
                    model.RoleId = sorg.Role_NameId;
                }
            }
            var result = await _employeeService.PostRoleUiList(model);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> DelRoleUiList(long designationId)
        {
            var result = await _employeeService.DelRoleUilist(designationId);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> DelRoleList(long designationId)
        {
            var result = await _employeeService.DelRoleList(designationId);
            var uilist = await _employeeService.GetAllRoleUiList();
            var ui = uilist.Where(r => r.RoleId == designationId).ToList();
            if (ui != null)
            {
                foreach (var u in ui)
                {
                    var delui = await _employeeService.DelRoleUilist(u.Role_Ui_ListId);
                }
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoleUiList()
        {
            var result = await _employeeService.GetAllRoleUiList();
            var designation = await _employeeService.GetAllUilist();
            var role = await _employeeService.GetAllRoleList();
            var resultRole = result.Where(r => r.EmployeeId == 0).ToList();
            foreach (var item in resultRole)
            {
                var d = designation.Where(u => u.UiListId == item.Ui_Id).FirstOrDefault();
                var r = role.Where(u => u.Role_ListId == item.RoleId).FirstOrDefault();
                if (r != null)
                {
                    item.RoleName = r.Role_Desc;
                    item.WorkDone = r.Work_Done;
                    if (d != null)
                    {
                        if (d.UI_Part_linked_to == 0)
                        {
                            item.UiLevel = d.UI_Name_Label;
                        }
                        else
                        {
                            var menu2 = designation.Where(m => m.UiListId == d.UI_Part_linked_to).FirstOrDefault();
                            if (menu2.UI_Part_linked_to == 0)
                            {
                                item.UiLevel = menu2.UI_Name_Label + "+" + d.UI_Name_Label;
                            }
                            else
                            {
                                var menu3 = designation.Where(m => m.UiListId == menu2.UI_Part_linked_to).FirstOrDefault();
                                if (menu3.UI_Part_linked_to == 0)
                                {
                                    item.UiLevel = menu3.UI_Name_Label + "+" + menu2.UI_Name_Label + "+" + d.UI_Name_Label;
                                }
                                else
                                {
                                    var menu4 = designation.Where(m => m.UiListId == menu3.UI_Part_linked_to).FirstOrDefault();
                                    if (menu4.UI_Part_linked_to == 0)
                                    {
                                        item.UiLevel = menu4.UI_Name_Label + "+" + menu3.UI_Name_Label + "+" + menu2.UI_Name_Label + "+" + d.UI_Name_Label;
                                    }
                                    else
                                    {
                                        var menu5 = designation.Where(m => m.UiListId == menu4.UI_Part_linked_to).FirstOrDefault();
                                        if (menu5.UI_Part_linked_to == 0)
                                        {
                                            item.UiLevel = menu5.UI_Name_Label + "+" + menu4.UI_Name_Label + "+" + menu3.UI_Name_Label + "+" + menu2.UI_Name_Label + "+" + d.UI_Name_Label;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (item.PermissionId == 1)
                    {
                        item.View_Allowed = "N";
                        item.Add_Edit_Allowed = "N";
                        item.Delete_Allowed = "N";
                        item.Approval_Allowed = "N";
                    }
                    else if (item.PermissionId == 2)
                    {
                        item.View_Allowed = "Y";
                        item.Add_Edit_Allowed = "N";
                        item.Delete_Allowed = "N";
                        item.Approval_Allowed = "N";
                    }
                    else if (item.PermissionId == 3)
                    {
                        item.View_Allowed = "Y";
                        item.Add_Edit_Allowed = "Y";
                        item.Delete_Allowed = "N";
                        item.Approval_Allowed = "N";
                    }
                    else if (item.PermissionId == 4)
                    {
                        item.View_Allowed = "Y";
                        item.Add_Edit_Allowed = "Y";
                        item.Delete_Allowed = "Y";
                        item.Approval_Allowed = "N";
                    }
                    else if (item.PermissionId == 5)
                    {
                        item.View_Allowed = "Y";
                        item.Add_Edit_Allowed = "Y";
                        item.Delete_Allowed = "Y";
                        item.Approval_Allowed = "Y";
                    }
                }
            }
            foreach (var item in role)
            {
                Role_UI_ListVM role_UI_s = new Role_UI_ListVM
                {
                    RoleId = item.Role_ListId,
                    RoleName = item.Role_Desc,
                    WorkDone =item.Work_Done
                };
                if (!resultRole.Any(r => r.RoleId == item.Role_ListId))
                {
                    resultRole.Add(role_UI_s);
                }

            }
            return Ok(resultRole);
        }
        [HttpGet]
        public async Task<IActionResult> GetRoleUiList(long roleId)
        {
            var result = await _employeeService.GetAllRoleUiList();
            result= result.Where(r => r.RoleId == roleId).ToList();
            var designation = await _employeeService.GetAllUilist();
            var role = await _employeeService.GetAllRoleList();
            var permission = await _employeeService.GetAllPermission();
            foreach (var item in result)
            {
                var d = designation.Where(u => u.UiListId == item.Ui_Id).FirstOrDefault();
                var r = role.Where(u => u.Role_ListId == item.RoleId).FirstOrDefault();
                item.RoleName = r.Role_Desc;
                if (d != null)
                {
                    if (d.UI_Part_linked_to == 0)
                    {
                        item.Menu1 = d.UI_Name_Label;
                    }
                    else
                    {
                        var menu2 = designation.Where(m => m.UiListId == d.UI_Part_linked_to).FirstOrDefault();
                        if (menu2.UI_Part_linked_to == 0)
                        {
                            item.Menu2 = d.UI_Name_Label;
                            item.Menu1 = menu2.UI_Name_Label;
                        }
                        else
                        {
                            var menu3 = designation.Where(m => m.UiListId == menu2.UI_Part_linked_to).FirstOrDefault();
                            if (menu3.UI_Part_linked_to == 0)
                            {
                                item.Menu1 = menu3.UI_Name_Label;
                                item.Menu2 = menu2.UI_Name_Label;
                                item.Menu3 = d.UI_Name_Label;
                            }
                            else
                            {
                                var menu4 = designation.Where(m => m.UiListId == menu3.UI_Part_linked_to).FirstOrDefault();
                                if (menu4.UI_Part_linked_to == 0)
                                {
                                    item.Menu1 = menu4.UI_Name_Label;
                                    item.Menu2 = menu3.UI_Name_Label;
                                    item.Menu3 = menu2.UI_Name_Label;
                                    item.Menu4 = d.UI_Name_Label;
                                }
                                else
                                {
                                    var menu5 = designation.Where(m => m.UiListId == menu4.UI_Part_linked_to).FirstOrDefault();
                                    if (menu5.UI_Part_linked_to == 0)
                                    {
                                        item.Menu1 = menu5.UI_Name_Label;
                                        item.Menu2 = menu4.UI_Name_Label;
                                        item.Menu3 = menu3.UI_Name_Label;
                                        item.Menu4 = menu2.UI_Name_Label;
                                        item.Menu5 = d.UI_Name_Label;
                                    }
                                }
                            }
                        }
                    }
                    var p = permission.Where(p => p.PermissionId == item.PermissionId).FirstOrDefault();
                    item.Permission = p.Permission;
                }
                
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmplRoleUiList(long employeeId)
        {
            var org = await _employeeService.GetAllOrgChart();
            var sorgs = org.Where(r => r.Dept_ID == employeeId).ToList();
            var designation = await _employeeService.GetAllUilist();
            var role = await _employeeService.GetAllRoleList();
            var roleui = await _employeeService.GetAllRoleUiList();
            if (sorgs!=null)
            {
                List<Role_UI_ListVM> role_UI_ListVMs = new List<Role_UI_ListVM>();
                foreach (var sorg in sorgs)
                {
                    var result = roleui.Where(r => r.RoleId == sorg.Role_NameId).ToList();
                    foreach (var item in result)
                    {
                        var d = designation.Where(u => u.UiListId == item.Ui_Id).FirstOrDefault();
                        var r = role.Where(u => u.Role_ListId == item.RoleId).FirstOrDefault();
                        item.RoleName = r.Role_Desc;
                        if (d != null)
                        {
                            if (d.UI_Part_linked_to == 0)
                            {
                                item.UiLevel = d.UI_Name_Label;
                                item.Menu1 = d.UI_Name_Label;
                            }
                            else
                            {
                                var menu2 = designation.Where(m => m.UiListId == d.UI_Part_linked_to).FirstOrDefault();
                                if (menu2.UI_Part_linked_to == 0)
                                {
                                    item.UiLevel = menu2.UI_Name_Label + "+" + d.UI_Name_Label;
                                    item.Menu2 = d.UI_Name_Label;
                                    item.Menu1 = menu2.UI_Name_Label;
                                }
                                else
                                {
                                    var menu3 = designation.Where(m => m.UiListId == menu2.UI_Part_linked_to).FirstOrDefault();
                                    if (menu3.UI_Part_linked_to == 0)
                                    {
                                        item.UiLevel = menu3.UI_Name_Label + "+" + menu2.UI_Name_Label + "+" + d.UI_Name_Label;
                                        item.Menu1 = menu3.UI_Name_Label;
                                        item.Menu2 = menu2.UI_Name_Label;
                                        item.Menu3 = d.UI_Name_Label;
                                    }
                                    else
                                    {
                                        var menu4 = designation.Where(m => m.UiListId == menu3.UI_Part_linked_to).FirstOrDefault();
                                        if (menu4.UI_Part_linked_to == 0)
                                        {
                                            item.UiLevel = menu4.UI_Name_Label + "+" + menu3.UI_Name_Label + "+" + menu2.UI_Name_Label + "+" + d.UI_Name_Label;
                                            item.Menu1 = menu4.UI_Name_Label;
                                            item.Menu2 = menu3.UI_Name_Label;
                                            item.Menu3 = menu2.UI_Name_Label;
                                            item.Menu4 = d.UI_Name_Label;
                                        }
                                        else
                                        {
                                            var menu5 = designation.Where(m => m.UiListId == menu4.UI_Part_linked_to).FirstOrDefault();
                                            if (menu5.UI_Part_linked_to == 0)
                                            {
                                                item.UiLevel = menu5.UI_Name_Label + "+" + menu4.UI_Name_Label + "+" + menu3.UI_Name_Label + "+" + menu2.UI_Name_Label + "+" + d.UI_Name_Label;
                                                item.Menu1 = menu5.UI_Name_Label;
                                                item.Menu2 = menu4.UI_Name_Label;
                                                item.Menu3 = menu3.UI_Name_Label;
                                                item.Menu4 = menu2.UI_Name_Label;
                                                item.Menu5 = d.UI_Name_Label;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (item.PermissionId == 1)
                        {
                            item.View_Allowed = "N";
                            item.Add_Edit_Allowed = "N";
                            item.Delete_Allowed = "N";
                            item.Approval_Allowed = "N";
                        }
                        else if (item.PermissionId == 2)
                        {
                            item.View_Allowed = "Y";
                            item.Add_Edit_Allowed = "N";
                            item.Delete_Allowed = "N";
                            item.Approval_Allowed = "N";
                        }
                        else if (item.PermissionId == 3)
                        {
                            item.View_Allowed = "Y";
                            item.Add_Edit_Allowed = "Y";
                            item.Delete_Allowed = "N";
                            item.Approval_Allowed = "N";
                        }
                        else if (item.PermissionId == 4)
                        {
                            item.View_Allowed = "Y";
                            item.Add_Edit_Allowed = "Y";
                            item.Delete_Allowed = "Y";
                            item.Approval_Allowed = "N";
                        }
                        else if (item.PermissionId == 5)
                        {
                            item.View_Allowed = "Y";
                            item.Add_Edit_Allowed = "Y";
                            item.Delete_Allowed = "Y";
                            item.Approval_Allowed = "Y";
                        }
                        role_UI_ListVMs.Add(item);
                    }
                }
                return Ok(role_UI_ListVMs);

            }
            return Ok(sorgs);
        }

        [HttpPost]
        public async Task<IActionResult> PostEmplRoleUiList(Empl_Role_ListVM model)
        {
            var result = await _employeeService.PostEmplRoleUiList(model);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> DelEmplRoleUilist(long designationId)
        {
            var result = await _employeeService.DelEmplRoleUilist(designationId);
            return Ok(result);
        }
    }
}
