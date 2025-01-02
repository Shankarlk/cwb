using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Domain;
using CWB.CompanySettings.Infrastructure;

namespace CWB.CompanySettings.Repositories.EmployeeMaster
{
    public class Permission_ListRepository : Repository<Permission_List>, IPermission_ListRepository
    {
        public Permission_ListRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}
