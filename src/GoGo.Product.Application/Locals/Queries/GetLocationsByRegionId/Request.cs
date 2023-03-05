using MediatR;

namespace GoGo.Product.Application.Locals.Queries.GetLocationsByRegionId
{
    public class Request : IRequest<Response>
    {
        public int RegionId { get; set; }
    }
}