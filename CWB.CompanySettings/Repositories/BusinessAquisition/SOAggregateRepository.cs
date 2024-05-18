using CWB.BusinessProcesses.Domain;
using CWB.BusinessProcesses.Infrastructure;
using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Infrastructure;


namespace CWB.CompanySettings.Repositories.BusinessAquisition
{
    public class SOAggregateRepository : Repository<SOAggregate>, ISOAggregateRepository
    {
        public SOAggregateRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}