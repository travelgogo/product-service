using GoGo.Product.Api.Endpoints;
using GoGo.Product.Application.Tours.Commands.CreateTour;
using GoGo.Product.Application.Tours.Queries.GetTours;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GoGo.Product.Api
{
    public static class Routing
    {
        public static void MapApiRouting(this WebApplication app)
        {
            app.MapTourEndpoints();
            app.MapLocalEndpoints();
        }
    }
}