using CWB.ProductionPlanWO.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CWB.ProductionPlanWO.Extensions
{
    public static class DataExtensions
    {
        public static void ConfigureAppDataEF(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WODbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("AppDB"), ServerVersion.AutoDetect(configuration.GetConnectionString("AppDB")), x => x.MigrationsAssembly("CWB.ProductionPlanWO"));
            });

        }
    }
}
