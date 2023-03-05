using MediatR;

namespace GoGo.Product.Application.Tours.Queries.GetTourById
{
    public class Request : IRequest<Response?>
    {
        public int Id { get; set; }
    }
}