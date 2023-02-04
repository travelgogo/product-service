using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoGo.Product.Domain.Entities;
using GoGo.Product.Domain.Repos;
using MediatR;

namespace GoGo.Product.Application.Tours.Queries.GetTours
{
    public class GetToursHandler : IRequestHandler<GetToursRequest, GetToursResponse>
    {
        private readonly IUnitOfWork _writeDb;

        public GetToursHandler(IUnitOfWork writeDb)
        {
            _writeDb = writeDb;
        }

        public async Task<GetToursResponse> Handle(GetToursRequest request, CancellationToken cancellationToken)
        {
            var tours = _writeDb.Repo<Tour>().GetAll().ToList();

            var res = new GetToursResponse
            {
                Tours = tours.Select(x => MapTour(x))
            };
            
            return await Task.FromResult(res);
            
        }

        private static TourItem MapTour(Tour request)
        {
            return new TourItem
            {
                Id = request.Id,
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
                Slot = request.Slot,
                // TourHasStartDates = request.TourStartDates.Select(x => new TourHasStartDate
                // {
                //     Status = x.Status,
                //     Description = x.Description,
                //     StartDate = x.StartDate,
                //     AdultPrice = x.AdultPrice,
                //     ChildrenFrom2To5Price = x.ChildrenFrom2To5Price,
                //     ChildrenFrom5To11Price = x.ChildrenFrom5To11Price,
                //     ChildrenUnder2Price = x.ChildrenUnder2Price,
                //     RemainSlots = request.Slot
                // }).ToList()
            };
        }
    }
}