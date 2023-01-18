
using GoGo.Product.Domain.Bases;

namespace GoGo.Product.Domain.Entities
{
    public class TourHasStartDate : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public byte Status { get; set; }
        public string? Description { get; set; }
        public int RemainSlots { get; set; }
        public int TourId { get; set; }
        public virtual Tour? Tour { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal? ChildrenUnder2Price { get; set; }
        public decimal? ChildrenFrom2To5Price { get; set; }
        public decimal? ChildrenFrom5To11Price { get; set; }
    }
}
