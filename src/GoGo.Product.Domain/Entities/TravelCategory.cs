
using GoGo.Product.Domain.Bases;

namespace GoGo.Product.Domain.Entities
{
    public class TravelCategory : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? MetaTitle { get; set; }
        public string? SeoLink { get; set; }
        public int Status { get; set; }
        public virtual ICollection<TravelRegion>? TravelRegions { get; set; }
    }
}
