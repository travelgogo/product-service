using MediatR;
using GoGo.Product.Domain.Repos;
using GoGo.Product.Domain.Entities;

namespace GoGo.Product.Application.Tours.Commands.CreateTour
{
    public class CreateTourHandler : IRequestHandler<CreateTourRequest, CreateTourResponse>
    {
        private readonly IReadDb _readDb;

        public CreateTourHandler(IReadDb readDb)
        {
            _readDb = readDb;
        }

        public async Task<CreateTourResponse> Handle(CreateTourRequest request, CancellationToken cancellationToken)
        {
            //await _readDb.Repo<Tour>().AddAsync(new Tour());
            return await Task.FromResult(new CreateTourResponse(false, "Error", 400));
        }
    }
}