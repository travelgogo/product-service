using MediatR;
using GoGo.Product.Domain.Entities;
using GoGo.Infrastructure.Repository;
using GoGo.Infrastructure.ServiceBus;
using GoGo.Infrastructure.BlobStorage;
using System.Text.RegularExpressions;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace GoGo.Product.Application.Tours.Commands.CreateTour
{
    partial class CreateTourHandler : IRequestHandler<CreateTourRequest, CreateTourResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobStorageManager _blobManager;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger _logger;

        public CreateTourHandler(IUnitOfWork unitOfWork, IBlobStorageManager blobManager, 
            IPublishEndpoint publishEndpoint, ILogger<CreateTourHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _blobManager = blobManager;
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task<CreateTourResponse> Handle(CreateTourRequest request, CancellationToken cancellationToken)
        {
            var tour = MapTour(request);
            Guid id = Guid.NewGuid();

            if(!string.IsNullOrEmpty(request.ThumbnailImage))
            {
                var base64 = Base64Regex().Replace(request.ThumbnailImage, string.Empty);
                var fileName = $"images/thumbnail-{id}.png";
                var content = Convert.FromBase64String(base64);
                var url = await _blobManager.UploadBlobAsync(fileName, content);
                tour.ThumbnailImage = url;
                request.ThumbnailImage = url;
            }

            if(!string.IsNullOrEmpty(request.ContentImage))
            {
                var base64 = Base64Regex().Replace(request.ContentImage, string.Empty);
                var fileName = $"images/content-{id}.png";
                var content = Convert.FromBase64String(base64);
                var url = await _blobManager.UploadBlobAsync(fileName, content);
                tour.ContentImage = url;
                request.ContentImage = url;
            }
            await _unitOfWork.Repo<Tour>().AddAsync(tour);
            await _unitOfWork.SaveChangeAsync();
            
            if (tour.Id > 0)
            {
                CreateTourEvent message = MapTourEvent(request);
                message.Id = tour.Id;
                await _publishEndpoint.Publish(message, cancellationToken);
                return new CreateTourResponse(true, "Create tour successfully!", 201);
            }

            return new CreateTourResponse(true, "Cannot create tour.", 500);
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
                Price = request.Price,
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
                Schedule = request.Schedule,
                TourStartDates = request.TourStartDates.Select(x => new TourStartDate
                {
                    // Status = x.Status,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    AdultPrice = x.AdultPrice,
                    ChildrenFrom2To5Price = x.ChildrenFrom2To5Price,
                    ChildrenFrom5To11Price = x.ChildrenFrom5To11Price,
                    ChildrenUnder2Price = x.ChildrenUnder2Price,
                    RemainSlot = request.Slot
                }).ToList()
            };
        }

        private static CreateTourEvent MapTourEvent(CreateTourRequest request)
        {
            return new CreateTourEvent
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
                TourStartDates = request.TourStartDates.Select(x => new TourStartDateItem
                {
                    // Status = x.Status,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    AdultPrice = x.AdultPrice,
                    ChildrenFrom2To5Price = x.ChildrenFrom2To5Price,
                    ChildrenFrom5To11Price = x.ChildrenFrom5To11Price,
                    ChildrenUnder2Price = x.ChildrenUnder2Price,
                    RemainSlot = request.Slot
                }).ToArray()
            };
        }

        [GeneratedRegex("^data:image\\/[a-zA-Z]+;base64,")]
        private static partial Regex Base64Regex();
    }
}