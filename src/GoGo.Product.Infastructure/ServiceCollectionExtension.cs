using GoGo.Product.Infastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GoGo.Product.Domain.Repos;
using GoGo.Product.Application.Shared.Abstraction;
using Azure.Messaging.ServiceBus;
using GoGo.Product.Infastructure.ServiceBus;

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
            
            services.AddSingleton(service =>
            {
                var configuration = service.GetRequiredService<IConfiguration>();
                var serviceBusSend = configuration["ServiceBusSend"];
                return new ServiceBusClient(serviceBusSend);
            });
            services.AddSingleton<IServiceBusDispatcher, ServiceBusDispatcher>();
            services.AddScoped(typeof(IRepository<>), typeof(ProductRepository<>));
            services.AddScoped<IReadDb, ReadDb>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}