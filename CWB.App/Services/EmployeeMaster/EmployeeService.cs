using CWB.App.AppUtils;
using CWB.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWB.App.Models.EmployeeMaster;
using CWB.CommonUtils.Common;

namespace CWB.App.Services.EmployeeMaster
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILoggerManager _logger;
        private readonly ApiUrls _apiUrls;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly HttpClient _httpClient;
        private readonly long tenantId;
        public EmployeeService(ILoggerManager logger, ApiUrls apiUrlsOptions, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _apiUrls = apiUrlsOptions;
           // _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            tenantId = long.Parse(AppUtil.GetTenantId(_httpContextAccessor.HttpContext.User));
        }
        public async Task<IEnumerable<EmployeeVM>> GetAllEmployee()
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/getallemployeelist/{tenantId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<List<EmployeeVM>>.GetAsync(uri, headers);
        }
        public async Task<IEnumerable<UiListVM>> GetAllUilist()
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/getalluilist/{tenantId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<List<UiListVM>>.GetAsync(uri, headers);
        }
        public async Task<UiListVM> PostUilist(UiListVM designationVM)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/postuilist");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            designationVM.TenantId = tenantId;
            return await RestHelper<UiListVM>.PostAsync(uri, designationVM, headers);
        }
        public async Task<EmployeeVM> PostEmployee(EmployeeVM designationVM)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/postemployee");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            designationVM.TenantId = tenantId;
            //RegisterViewModel model = new RegisterViewModel()
            //{
            //    Username = designationVM.Email,
            //    Email = designationVM.Email,
            //    FirstName = designationVM.Employee_name,
            //    LastName = designationVM.Employee_name,
            //    Password = designationVM.Password,
            //    PhoneNumber = designationVM.Phone,
            //    TenantId = "5"
            //};
            //var uriacc = new Uri(_apiUrls.Idenitity + $"/account/register");
            //await RestHelper<RegisterViewModel>.PostAsync(uriacc, model, headers);
            //var response = await _httpClient.PostAsync($"{_apiUrls.Idenitity}/register", model);
            return await RestHelper<EmployeeVM>.PostAsync(uri, designationVM, headers);
        }
        public async Task<bool> DelEmployee(long designationId)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/delemployee/{designationId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<bool>.GetAsync(uri, headers);
        }
        public async Task<bool> DelUiList(long designationId)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/deluilist/{designationId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<bool>.GetAsync(uri, headers);
        }
        public async Task<IEnumerable<Role_ListVM>> GetAllRoleList()
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/getallrolelist/{tenantId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<List<Role_ListVM>>.GetAsync(uri, headers);
        }
        public async Task<Role_ListVM> PostRolelist(Role_ListVM designationVM)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/postrolelist");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            designationVM.TenantId = tenantId;
            return await RestHelper<Role_ListVM>.PostAsync(uri, designationVM, headers);
        }
        public async Task<bool> DelRoleList(long designationId)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/delrolelist/{designationId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<bool>.GetAsync(uri, headers);
        }
        public async Task<IEnumerable<Org_ChartVM>> GetAllOrgChart()
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/getallorgchart/{tenantId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<List<Org_ChartVM>>.GetAsync(uri, headers);
        }
        public async Task<Org_ChartVM> PostOrgChart(Org_ChartVM designationVM)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/postorgchart");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            designationVM.TenantId = tenantId;
            return await RestHelper<Org_ChartVM>.PostAsync(uri, designationVM, headers);
        }
        public async Task<bool> DelOrgChart(long designationId)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/delorgchart/{designationId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<bool>.GetAsync(uri, headers);
        }
        public async Task<IEnumerable<Permission_ListVM>> GetAllPermission()
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/getallpermissionlist/{tenantId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<List<Permission_ListVM>>.GetAsync(uri, headers);
        }
        public async Task<IEnumerable<Role_UI_ListVM>> GetAllRoleUiList()
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/getallroleuilist/{tenantId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<List<Role_UI_ListVM>>.GetAsync(uri, headers);
        }
        public async Task<Role_UI_ListVM> PostRoleUiList(Role_UI_ListVM designationVM)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/postroleuilist");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            designationVM.TenantId = tenantId;
            return await RestHelper<Role_UI_ListVM>.PostAsync(uri, designationVM, headers);
        }
        public async Task<bool> DelRoleUilist(long designationId)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/delroleuilist/{designationId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<bool>.GetAsync(uri, headers);
        }
        public async Task<IEnumerable<Empl_Role_ListVM>> GetAllEmplRoleUiList()
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/getallemplrolelist/{tenantId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<List<Empl_Role_ListVM>>.GetAsync(uri, headers);
        }
        public async Task<Empl_Role_ListVM> PostEmplRoleUiList(Empl_Role_ListVM designationVM)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/postemplrolelist");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            designationVM.TenantId = tenantId;
            return await RestHelper<Empl_Role_ListVM>.PostAsync(uri, designationVM, headers);
        }
        public async Task<bool> DelEmplRoleUilist(long designationId)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbcs/delemplrolelist/{designationId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<bool>.GetAsync(uri, headers);
        }
    }
}
