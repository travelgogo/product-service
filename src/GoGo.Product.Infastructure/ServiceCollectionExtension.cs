using GoGo.Product.Infastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GoGo.Infrastructure.Repository;
using GoGo.Infrastructure.BlobStorage;
using MassTransit;
using GoGo.Product.Application.Tours.Commands.CreateTour;
using MediatR;

namespace GoGo.Product.Infastructure
{
    public static class ServiceCollectionExtension
    {
        public static void AddAppInfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(configuration["Azure:SqlServer:ProductConnection"]);
            });
            services.AddRepository<ProductDbContext>();
            services.AddBlobStorage();
            services.AddMassTransit(config =>
            {
                config.UsingAzureServiceBus((context, cfg) =>
                {
                    cfg.Message<CreateTourEvent>(cfg =>
                    {
                        cfg.SetEntityName("pds.tour.created");
                    });
                    cfg.Publish<IBaseRequest>(x => x.Exclude = true);
                    cfg.Publish<CreateTourResponse>(x => x.Exclude = true);
                    cfg.Publish<CreateTourRequest>(x => x.Exclude = true);
                    cfg.Host(configuration["Azure:ServiceBus:ServiceBusManage"]);
                });
            });
        }

        public static void AddFuncInfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(configuration["Azure:SqlServer:ProductConnection"]);
            });
            services.AddRepository<ProductDbContext>();
            services.AddBlobStorage();
        }
    }
}