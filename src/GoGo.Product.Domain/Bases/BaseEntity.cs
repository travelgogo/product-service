using GoGo.Infrastructure.Repository;

namespace GoGo.Product.Domain.Bases
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime UtcDateCreated { get; set; } = DateTime.UtcNow;
        public DateTimeOffset? UtcDateUpdated { get; set; }
    }
}