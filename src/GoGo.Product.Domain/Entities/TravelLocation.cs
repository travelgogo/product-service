using GoGo.Product.Domain.Bases;

namespace GoGo.Product.Domain.Entities
{
    public class TravelLocation : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? MetaTitle { get; set; }
        public string? SeoLink { get; set; }
        public int Status { get; set; }
        public int TravelRegionId { get; set; }
        public virtual TravelRegion? TravelRegion { get; set; }
    }
}
