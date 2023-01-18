using GoGo.Product.Application.Tours.Commands.CreateTour;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GoGo.Product.Api
{
    public static class Routing
    {
        public static void MapAppRouting(this WebApplication app)
        {
            app.MapGet("tours/{id}", [Authorize("HasAdminRole")] (int id) => 
            {
                return "tours";
            });

            app.MapPost("tours", [Authorize("HasAdminRole")] async (CreateTourRequest request, IMediator _mediator) => 
            {
                var result = await _mediator.Send(request);

                if(result.IsSuccess)
                    return Results.Created("tours", result.Message);
                    
                return Results.BadRequest(result.Message);
            });
        }
    }
}