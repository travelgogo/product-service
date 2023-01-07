
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

    }
}
