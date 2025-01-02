using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Domain;
using CWB.CompanySettings.Infrastructure;

namespace CWB.CompanySettings.Repositories.EmployeeMaster
{
    public class EmployeeMasterRepository : Repository<Employee>, IEmployeeMasterRepository
    {
        public EmployeeMasterRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}
