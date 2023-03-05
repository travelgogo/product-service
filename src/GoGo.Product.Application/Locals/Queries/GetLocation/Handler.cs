using GoGo.Infrastructure.Repository;
using GoGo.Product.Domain.Entities;
using MediatR;

namespace GoGo.Product.Application.Locals.Queries.GetLocation
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            _unitOfWork.Repo<TravelLocation>().GetAsync(request.LocationId);
            throw new NotImplementedException();
        }
    }
}