using CWB.BusinessProcesses.Domain;
using CWB.BusinessProcesses.Infrastructure;
using CWB.BusinessProcesses.ViewModels;
using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Infrastructure;


namespace CWB.CompanySettings.Repositories.BusinessAquisition
{
    public class OrderStatusRepository : Repository<OrderStatusVM>, IOrderStatusRepository
    {
        public OrderStatusRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}