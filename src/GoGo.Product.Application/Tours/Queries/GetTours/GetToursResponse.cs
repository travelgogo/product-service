using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoGo.Product.Application.Tours.Queries.GetTours
{
    public class GetToursResponse
    {
        public IEnumerable<TourItem> Tours { get; set; } = Enumerable.Empty<TourItem>();
    }

    public class TourItem
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public string? Note { get; set; }
        public int TourDay { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal? ChildrenUnder2Price { get; set; }
        public decimal? ChildrenFrom2To5Price { get; set; }
        public decimal? ChildrenFrom5To11Price { get; set; }
        public decimal Price { get; set; }
        public int? Status { get; set; }
        public decimal? PromotionPrice { get; set; }
        public byte? Rating { get; set; }
        public int? TotalRating { get; set; }
        public string? MetaTitle { get; set; }
        public string? ThumbnailImage { get; set; }
        public string? Avatar { get; set; }
        public string? SeoLink { get; set; }
        public int TravelLocationId { get; set; }
        public int Slot { get; set; }
    }
}