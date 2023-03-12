using GoGo.Product.Api.Endpoints;

namespace GoGo.Product.Api
{
    public static class Routing
    {
        public static void MapApiRouting(this WebApplication app)
        {
            app.MapTourEndpoints();
            app.MapLocalEndpoints();
            app.MapGet("/", () => "Product service is running...");
        }
    }
}