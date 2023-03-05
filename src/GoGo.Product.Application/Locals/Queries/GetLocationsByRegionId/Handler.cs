using GoGo.Infrastructure.Repository;
using GoGo.Product.Domain.Entities;
using MediatR;

namespace GoGo.Product.Application.Locals.Queries.GetLocationsByRegionId
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var data = _unitOfWork.Repo<TravelLocation>().GetAsync(x => x.TravelRegionId == request.RegionId);
            var res = new Response
            {
                Locations = data.Select(x => new LocationItem
                {
                    Id = x.Id,
                    Name = x.Name ?? string.Empty
                })
            };

            return await Task.FromResult(res);
        }
    }
}