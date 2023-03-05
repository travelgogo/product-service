using GoGo.Infrastructure.Repository;
using GoGo.Product.Domain.Entities;
using MediatR;

namespace GoGo.Product.Application.Locals.Queries.GetRegionsByCategoryId
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
            var data = _unitOfWork.Repo<TravelRegion>().GetAsync(x => x.TravelCategoryId == request.CategoryId).ToList();
            var res = new Response
            {
                Regions = data.Select(x => new RegionItem
                {
                    Id = x.Id,
                    Name = x.Name ?? string.Empty
                })
            };

            return await Task.FromResult(res);
        }
    }
}