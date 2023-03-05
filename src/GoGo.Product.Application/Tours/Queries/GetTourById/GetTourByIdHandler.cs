using GoGo.Infrastructure.Repository;
using GoGo.Product.Domain.Entities;
using MediatR;

namespace GoGo.Product.Application.Tours.Queries.GetTourById
{
    public class GetTourByIdHandler : IRequestHandler<GetTourByIdRequest, GetTourByIdResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTourByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetTourByIdResponse?> Handle(GetTourByIdRequest request, CancellationToken cancellationToken)
        {
            var tour = await _unitOfWork.Repo<Tour>().GetAsync(request.Id);
            if(tour != null)
            {
                return MapTour(tour);
            }
            return null;
        }

        private static GetTourByIdResponse MapTour(Tour request)
        {
            return new GetTourByIdResponse
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
                Price = request.Price,
                PromotionPrice = request.PromotionPrice,
                Rating = request.Rating,
                SeoLink = request.SeoLink,
                Status = request.Status,
                ThumbnailImage = request.ThumbnailImage,
                TotalRating = request.TotalRating,
                TourDay = request.TourDay,
                TravelLocationId = request.TravelLocationId,
                Slot = request.Slot,
                Schedule = request.Schedule,
                TourStartDates =  request.TourStartDates?.Select(x => new TourStartDateItem
                {
                    // Status = x.Status,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    AdultPrice = x.AdultPrice,
                    ChildrenFrom2To5Price = x.ChildrenFrom2To5Price,
                    ChildrenFrom5To11Price = x.ChildrenFrom5To11Price,
                    ChildrenUnder2Price = x.ChildrenUnder2Price,
                    RemainSlot = request.Slot
                }).ToArray() ?? new List<TourStartDateItem>().ToArray()
            };
        }
    }
}