
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GoGo.Product.Api.Endpoints
{
    public static class TravelLocalEndpoint
    {
        public static void MapLocalEndpoints(this WebApplication app)
        {
            app.MapGet("categories", [Authorize] async (IMediator _mediator) => 
            {
                var request = new Application.Locals.Queries.GetCategories.Request();
                var res = await _mediator.Send(request);
                return TypedResults.Ok(res);
            });

            app.MapGet("categories/{categoryId}/regions", 
                [Authorize("HasAdminRole")] async (IMediator _mediator, int categoryId) => 
            {
                var request = new Application.Locals.Queries.GetRegionsByCategoryId.Request
                {
                    CategoryId = categoryId
                };

                var res = await _mediator.Send(request);
                return TypedResults.Ok(res);
            });

            app.MapGet("regions/{regionId}/locations", 
                [Authorize("HasAdminRole")] async (IMediator _mediator, int regionId) => 
            {
                var request = new Application.Locals.Queries.GetLocationsByRegionId.Request
                {
                    RegionId = regionId
                };
                
                var res = await _mediator.Send(request);
                return TypedResults.Ok(res);
            });

            app.MapGet("locations/{locationId}", 
                [Authorize("HasAdminRole")] (int locationId) => 
            {
                return "tours";
            });
        }
    }
}