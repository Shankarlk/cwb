using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Domain;
using CWB.CompanySettings.Infrastructure;

namespace CWB.CompanySettings.Repositories.EmployeeMaster
{
    public class Role_ListRepository : Repository<Role_List>, IRole_ListRepository
    {
        public Role_ListRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}
