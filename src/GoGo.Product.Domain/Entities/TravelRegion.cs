using GoGo.Product.Domain.Bases;

namespace GoGo.Product.Domain.Entities
{
    public class TravelRegion : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? MetaTitle { get; set; }
        public string? SeoLink { get; set; }
        public int Status { get; set; }
        public int TravelCategoryId { get; set; }
        public virtual TravelCategory? TravelCategory { get; set; }
        public virtual ICollection<TravelLocation>? TravelLocations { get; set; }
        
    }
}
