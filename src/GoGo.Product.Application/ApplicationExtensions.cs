using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace GoGo.Product.Application
{
    public static class ApplicationExtensions
    {
        public static void AddAppExtension(this IServiceCollection service)
        {
            service.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}