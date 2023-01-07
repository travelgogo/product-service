using GoGo.Product.Infastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GoGo.Product.Domain.Repos;

namespace GoGo.Product.Infastructure
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppInfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ProductConection"));
            });
            
            services.AddScoped(typeof(IRepository<>), typeof(ProductRepository<>));
            services.AddScoped<IReadDb, ReadDb>();
            services.AddScoped<IWriteDb, WriteDb>();
        }
    }
}