using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Domain;
using CWB.CompanySettings.Infrastructure;

namespace CWB.CompanySettings.Repositories.EmployeeMaster
{
    public class UiListRepository : Repository<UiList>, IUi_ListRepository
    {
        public UiListRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}
