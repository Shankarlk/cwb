using CWB.App.Models.EmployeeMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.App.Services.EmployeeMaster
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeVM>> GetAllEmployee();
        Task<EmployeeVM> PostEmployee(EmployeeVM designationVM);
        Task<bool> DelEmployee(long designationId);
        Task<IEnumerable<UiListVM>> GetAllUilist();
        Task<UiListVM> PostUilist(UiListVM designationVM);
        Task<bool> DelUiList(long designationId);
        Task<IEnumerable<Role_ListVM>> GetAllRoleList();
        Task<Role_ListVM> PostRolelist(Role_ListVM designationVM);
        Task<bool> DelRoleList(long designationId);
        Task<IEnumerable<Org_ChartVM>> GetAllOrgChart();
        Task<Org_ChartVM> PostOrgChart(Org_ChartVM designationVM);
        Task<bool> DelOrgChart(long designationId);
        Task<IEnumerable<Permission_ListVM>> GetAllPermission();
        Task<IEnumerable<Role_UI_ListVM>> GetAllRoleUiList();
        Task<Role_UI_ListVM> PostRoleUiList(Role_UI_ListVM designationVM);
        Task<bool> DelRoleUilist(long designationId);
        Task<IEnumerable<Empl_Role_ListVM>> GetAllEmplRoleUiList();
        Task<Empl_Role_ListVM> PostEmplRoleUiList(Empl_Role_ListVM designationVM);
        Task<bool> DelEmplRoleUilist(long designationId);



    }
}
