using DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Util
{
    public static class DependencyConfigurationDAL
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
