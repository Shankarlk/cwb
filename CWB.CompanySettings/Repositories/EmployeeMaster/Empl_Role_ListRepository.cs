using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Domain;
using CWB.CompanySettings.Infrastructure;

namespace CWB.CompanySettings.Repositories.EmployeeMaster
{
    public class Empl_Role_ListRepository : Repository<Empl_Role_List>, IEmpl_Role_ListRepository
    {
        public Empl_Role_ListRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}
