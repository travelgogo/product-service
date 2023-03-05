using GoGo.Product.Application.Models;

namespace GoGo.Product.Application.Locals.Queries.GetRegionsByCategoryId
{
    public class Response
    {
        public IEnumerable<RegionItem> Regions { get; set; } = Enumerable.Empty<RegionItem>();
    }

    public class RegionItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}