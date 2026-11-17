using BLL.Services;
using CORE.Abstracts.IServices;
using CORE.Utils;
using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Middlewares
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options => options.UseSqlite(configuration.GetConnectionString("store")));

            services.AddScoped<IUnitOfWork, UnitOfWork<StoreContext>>();

            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
