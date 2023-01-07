using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoGo.Product.Domain.Bases
{
    public class BaseEntity : CoreEntity
    {
        public int Id { get; set; }
        public DateTime UtcDateCreated { get; set; } = DateTime.UtcNow;
        public DateTimeOffset? UtcDateUpdated { get; set; }
    }
}