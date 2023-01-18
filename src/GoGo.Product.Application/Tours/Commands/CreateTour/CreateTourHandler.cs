using MediatR;
using GoGo.Product.Domain.Repos;
using GoGo.Product.Domain.Entities;

namespace GoGo.Product.Application.Tours.Commands.CreateTour
{
    public class CreateTourHandler : IRequestHandler<CreateTourRequest, CreateTourResponse>
    {
        private readonly IWriteDb _writeDb;

        public CreateTourHandler(IWriteDb writeDb)
        {
            _writeDb = writeDb;
        }

        public async Task<CreateTourResponse> Handle(CreateTourRequest request, CancellationToken cancellationToken)
        {
            var tour = MapTour(request);
            await _writeDb.Repo<Tour>().AddAsync(tour);
            await _writeDb.SaveChangeAsync(CancellationToken.None);
            return await Task.FromResult(new CreateTourResponse(true, "Create tour successfully", 201));
        }

        private static Tour MapTour(CreateTourRequest request)
        {
            return new Tour
            {
                AdultPrice = request.AdultPrice,
                Avatar = request.Avatar,
                ChildrenFrom2To5Price = request.ChildrenFrom2To5Price,
                ChildrenFrom5To11Price = request.ChildrenFrom5To11Price,
                ChildrenUnder2Price = request.ChildrenUnder2Price,
                Code = request.Code,
                Description = request.Description,
                Detail = request.Detail,
                MetaTitle = request.MetaTitle,
                Name = request.Name,
                Note = request.Note,
                Price= request.Price,
                PromotionPrice = request.PromotionPrice,
                Rating = request.Rating,
                SeoLink = request.SeoLink,
                Status = request.Status,
                ThumbnailImage = request.ThumbnailImage,
                TotalRating = request.TotalRating,
                TourDay = request.TourDay,
                TravelLocationId = request.TravelLocationId,
                UtcDateCreated = DateTime.Now,
                Slot = request.Slot,
                TourHasStartDates = request.TourStartDates.Select(x => new TourHasStartDate
                {
                    Status = x.Status,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    AdultPrice = x.AdultPrice,
                    ChildrenFrom2To5Price = x.ChildrenFrom2To5Price,
                    ChildrenFrom5To11Price = x.ChildrenFrom5To11Price,
                    ChildrenUnder2Price = x.ChildrenUnder2Price,
                    RemainSlots = request.Slot
                }).ToList()
            };
        }
    }
}