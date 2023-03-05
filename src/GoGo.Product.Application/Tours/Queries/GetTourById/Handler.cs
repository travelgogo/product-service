using GoGo.Infrastructure.Repository;
using GoGo.Product.Domain.Entities;
using MediatR;

namespace GoGo.Product.Application.Tours.Queries.GetTourById
{
    public class Handler : IRequestHandler<Request, Response?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response?> Handle(Request request, CancellationToken cancellationToken)
        {
            var tour = await _unitOfWork.Repo<Tour>().GetAsync(request.Id, new string[] {"TourStartDates"});
            if(tour != null)
            {
                return MapTour(tour);
            }
            return null;
        }

        private static Response MapTour(Tour request)
        {
            byte startDateNo = 1;
            return new Response
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
                ContentImage = request.ContentImage,
                TotalRating = request.TotalRating,
                TourDay = request.TourDay,
                TravelLocationId = request.TravelLocationId,
                Slot = request.Slot,
                Schedule = request.Schedule,
                TourStartDates =  request.TourStartDates?.Select(x => new TourStartDateItem
                {
                    No = startDateNo++,
                    // Status = x.Status,
                    Description = x.Description,
                    StartDate = x.StartDate.ToString("yyyy-MM-dd HH:mm"),
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