using CWB.BusinessProcesses.Domain;
using CWB.BusinessProcesses.Infrastructure;
using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Infrastructure;


namespace CWB.CompanySettings.Repositories.BusinessAquisition
{
    public class SalesOrderRepository : Repository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}