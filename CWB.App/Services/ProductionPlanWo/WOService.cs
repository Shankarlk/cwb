using CWB.App.AppUtils;
using CWB.App.Models.BusinessProcesses;
using CWB.CommonUtils.Common;
using CWB.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWB.App.Services.ProductionPlanWo
{
    public class WOService:IWOService
    {
        private readonly ILoggerManager _logger;
        private readonly ApiUrls _apiUrls;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly long tenantId;

        public WOService(ILoggerManager logger, IOptions<ApiUrls> apiUrlsOptions, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _apiUrls = apiUrlsOptions.Value;
            _httpContextAccessor = httpContextAccessor;
            tenantId = long.Parse(AppUtil.GetTenantId(_httpContextAccessor.HttpContext.User));
        }

        public async Task<IEnumerable<WOSOVM>> GetSoWoRel(long workOrderId)
        {
            var uri = new Uri(_apiUrls.Gateway + $"/cwbpwo/getsowo/{workOrderId}");
            var headers = await AppUtil.GetAuthToken(_httpContextAccessor.HttpContext);
            return await RestHelper<IEnumerable<WOSOVM>>.GetAsync(uri, headers);
        }
    }
}
