using MediatR;

namespace GoGo.Product.Application.Tours.Commands.UpdateTour
{
    public class Handler : IRequestHandler<Request, Response>
    {
        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}