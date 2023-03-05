using GoGo.Product.Application.Tours.Commands.CreateTour;
using GoGo.Product.Application.Tours.Queries.GetTours;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using UpdateTourRequest = GoGo.Product.Application.Tours.Commands.UpdateTour.Request;

namespace GoGo.Product.Api.Endpoints
{
    public static class TourEndpoint
    {
        public static void MapTourEndpoints(this WebApplication app)
        {
            app.MapGet("tours/{id}", [Authorize("HasAdminRole")] async (IMediator _mediator, int id) => 
            {
                var request = new Application.Tours.Queries.GetTourById.Request
                {
                    Id = id
                };

                return await _mediator.Send(request);
            });

            app.MapGet("tours", [Authorize] async (IMediator _mediator) => 
            {
                var request = new GetToursRequest();
                var res = await _mediator.Send(request);
                return Results.Ok(res);
            });

            app.MapPost("tours", [Authorize] async (CreateTourRequest request, IMediator _mediator, ILogger _logger) => 
            {
                try
                {
                    var result = await _mediator.Send(request);

                    if(result.IsSuccess)
                        return Results.Created("tours", result.Message);
                        
                    return Results.BadRequest(result.Message);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Cannot create tour!");
                    return TypedResults.StatusCode(500);
                }
                
            });

            app.MapPut("tours/{id}", [Authorize("HasAdminRole")] async (UpdateTourRequest request, int id, IMediator _mediator) => 
            {
                var res = await _mediator.Send(request);
                return TypedResults.Ok(res);
            });
            
            app.MapDelete("tours/{id}", [Authorize("HasAdminRole")] async (int id, IMediator _mediator) => 
            {
                await Task.Yield();
                throw new NotImplementedException();
            });
        }
    }
}