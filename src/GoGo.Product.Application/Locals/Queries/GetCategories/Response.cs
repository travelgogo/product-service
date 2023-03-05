using GoGo.Product.Application.Models;

namespace GoGo.Product.Application.Locals.Queries.GetCategories
{
    public class Response
    {
        public IEnumerable<CategoryItem> Categories { get; set; } = Enumerable.Empty<CategoryItem>();

    }

    public class CategoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}