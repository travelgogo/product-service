using MediatR;

namespace GoGo.Product.Application.Locals.Queries.GetLocation
{
    public class Request : IRequest<Response>
    {
        public int LocationId { get; set; }
    }
}