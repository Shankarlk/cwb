using CWB.BusinessProcesses.Domain;
using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Infrastructure;


namespace CWB.CompanySettings.Repositories.BusinessAquisition
{
    public class POLogRepository : Repository<POLog>, IPOLogRepository
    {
        public POLogRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}