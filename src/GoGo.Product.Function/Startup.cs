using GoGo.Product.Function.Helpers.BlobStorage;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(GoGo.Product.Function.Startup))]
namespace GoGo.Product.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton(service =>
            {
                var config = service.GetRequiredService<IConfiguration>();
                var option = new BlobStorageOptions();
                var blobSection = config.GetSection("BlobStorage:Azure");
                blobSection.Bind(option);
                return option;
            });
            builder.Services.AddSingleton<IBlobStorageManager, BlobStorageManager>();
        }
    }
}