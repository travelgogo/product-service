using GoGo.Product.Application.Tours.Commands.CreateTour;
using MediatR;

namespace GoGo.Product.Api
{
    public static class Routing
    {
        public static void MapAppRouting(this WebApplication app)
        {
            app.MapGet("tours/id", (int id) => 
            {
                return "tours";
            });

            app.MapPost("tours", async (CreateTourRequest request, IMediator _mediator) => 
            {
                var result = await _mediator.Send(request);

                if(result.IsSuccess)
                    return Results.Created("tours", request);
                    
                return Results.BadRequest(result.Message);
            });
        }
    }
}