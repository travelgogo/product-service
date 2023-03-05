using MediatR;

namespace GoGo.Product.Application.Locals.Queries.GetRegionsByCategoryId
{
    public class Request : IRequest<Response>
    {
        public int CategoryId { get; set; }
    }
}