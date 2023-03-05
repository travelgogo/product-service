using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GoGo.Product.Infastructure;

[assembly: FunctionsStartup(typeof(GoGo.Product.Function.Startup))]
namespace GoGo.Product.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;
            builder.Services.AddFuncInfastructure(configuration);
        }
    }
}