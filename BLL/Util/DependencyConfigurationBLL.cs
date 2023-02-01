

using BLL.Mapper.Profiles;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Util
{
    public static class DependencyConfigurationBLL
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(EntityToBusinessModelMapperProfile));
        }
    }
}
