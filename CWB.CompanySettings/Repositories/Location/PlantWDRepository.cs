using CWB.CommonUtils.Common.Repositories;
using CWB.CompanySettings.Domain;
using CWB.CompanySettings.Infrastructure;

namespace CWB.CompanySettings.Repositories.Location
{
    public class PlantWDRepository : Repository<PlantWorkingDetails>, IPlantWDRepository
    {
        public PlantWDRepository(CompanySettingsDbContext context)
         : base(context)
        { }
    }
}