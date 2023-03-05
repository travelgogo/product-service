using GoGo.Product.Application.Models;

namespace GoGo.Product.Application.Locals.Queries.GetLocationsByRegionId
{
    public class Response
    {
        public IEnumerable<LocationItem> Locations { get; set; } = Enumerable.Empty<LocationItem>();
    }

    public class LocationItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}