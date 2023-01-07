using GoGo.Product.Domain.Bases;

namespace GoGo.Product.Domain.Entities
{
    public class TourRating : BaseEntity
    {
        public int? OneStarAmount { get; set; }
        public int? TwoStarAmount { get; set; }
        public int? ThreeStarAmount { get; set; }
        public int? FourStarAmount { get; set; }
        public int? FiveStarAmount { get; set; }
        public int TourId { get; set; }
        public virtual Tour? Tour { get; set; }

    }
}
