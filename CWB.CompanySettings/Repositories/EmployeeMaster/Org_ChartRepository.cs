using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Domain;
using CWB.CompanySettings.Infrastructure;

namespace CWB.CompanySettings.Repositories.EmployeeMaster
{
    public class Org_ChartRepository : Repository<Org_Chart>, IOrg_ChartRepository
    {
        public Org_ChartRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}
