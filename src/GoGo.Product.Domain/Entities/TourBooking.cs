using GoGo.Product.Domain.Bases;

namespace GoGo.Product.Domain.Entities
{
    public class TourBooking : BaseEntity
    {
        public string? Code { get; set; }
        public int TourId { get; set; }
        public int TourHasStartDateId { get; set; }
        public DateTime BookingDate { get; set; }
        public string? BookerFullName { get; set; }
        public string? BookerEmail { get; set; }
        public string? BookerPhone { get; set; }
        public string? BookerAddress { get; set; }
        public string? BookerNote { get; set; }
        public int AdultQuantity { get; set; }
        public int? ChildrenUnder2 { get; set; }
        public int? ChildrenFrom2To5 { get; set; }
        public int? ChildrenFrom5To11 { get; set; }
        public decimal TotalPrice { get; set; }
        public int Status { get; set; }
        public virtual Tour? Tour { get; set; }
    }
}
