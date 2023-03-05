using GoGo.Product.Domain.Entities;
using GoGo.Infrastructure.Repository;
using MediatR;

namespace GoGo.Product.Application.Locals.Queries.GetCategories
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
            var data = _unitOfWork.Repo<TravelCategory>().GetAsync().ToList();
            
            var res = new Response
            {
                Categories = data.Select(x => new CategoryItem
                {
                    Id = x.Id,
                    Name = x.Name ?? string.Empty
                })
            };
            
            return await Task.FromResult(res);
        }
    }
}