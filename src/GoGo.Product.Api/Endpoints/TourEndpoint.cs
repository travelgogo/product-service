using GoGo.Product.Application.Tours.Commands.CreateTour;
using GoGo.Product.Application.Tours.Queries.GetTours;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GoGo.Product.Api.Endpoints
{
    public static class TourEndpoint
    {
        public static void MapTourEndpoints(this WebApplication app)
        {
            app.MapGet("tours/{id}", [Authorize("HasAdminRole")] (int id) => 
            {
                return "tours";
            });

            app.MapGet("tours", [Authorize] async (IMediator _mediator) => 
            {
                var request = new GetToursRequest();
                var res = await _mediator.Send(request);
                return Results.Ok(res);
            });

            app.MapPost("tours", [Authorize] async (CreateTourRequest request, IMediator _mediator) => 
            {
                var result = await _mediator.Send(request);

                if(result.IsSuccess)
                    return Results.Created("tours", result.Message);
                    
                return Results.BadRequest(result.Message);
            });
        }
    }
}