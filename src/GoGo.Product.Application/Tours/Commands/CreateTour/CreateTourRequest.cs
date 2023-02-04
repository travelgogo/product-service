using MediatR;
using System;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GoGo.Product.Application.Tours.Commands.CreateTour
{
    public class CreateTourRequest : IRequest<CreateTourResponse>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Schedule { get; set; }
        public string? Detail { get; set; }
        public string? Note { get; set; }
        public int TourDay { get; set; }
        public decimal AdultPrice { get; set; }
        // [JsonProperty("under2Price")]
        [JsonPropertyName("under2Price")]
        public decimal? ChildrenUnder2Price { get; set; }
        // [JsonProperty("to5Price")]
        [JsonPropertyName("to5Price")]
        public decimal? ChildrenFrom2To5Price { get; set; }
        // [JsonProperty("to10Price")]
        [JsonPropertyName("to11Price")]
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
        // [JsonProperty("locationId")]
        [JsonPropertyName("locationId")]
        public int TravelLocationId { get; set; }
        public int Slot { get; set; }
        // [JsonProperty("startDates")]
        [JsonPropertyName("startDates")]
        public TourStartDateItem[] TourStartDates { get; set; } = new List<TourStartDateItem>().ToArray();
    }

    public class TourStartDateItem
    {
        public DateTime StartDate { get; set; }
        public decimal AdultPrice { get; set; }
        [JsonPropertyName("under2Price")]
        public decimal? ChildrenUnder2Price { get; set; }
        [JsonPropertyName("to5Price")]
        public decimal? ChildrenFrom2To5Price { get; set; }
        [JsonPropertyName("to11Price")]
        public decimal? ChildrenFrom5To11Price { get; set; }
        public string? Description { get; set; }
        // public byte Status { get; set; }
        public int RemainSlot { get; set; }
    }
}