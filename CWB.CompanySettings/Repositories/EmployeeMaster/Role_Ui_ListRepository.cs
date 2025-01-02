using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Domain;
using CWB.CompanySettings.Infrastructure;

namespace CWB.CompanySettings.Repositories.EmployeeMaster
{
    public class Role_Ui_ListRepository : Repository<Role_Ui_List>, IRole_Ui_ListRepository
    {
        public Role_Ui_ListRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}
