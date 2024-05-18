using CWB.BusinessProcesses.Domain;
using CWB.BusinessProcesses.Infrastructure;
using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Infrastructure;


namespace CWB.CompanySettings.Repositories.BusinessAquisition
{
    public class DeliveryScheduleRepository : Repository<DeliverySchedule>, IDeliveryScheduleRepository
    {
        public DeliveryScheduleRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}