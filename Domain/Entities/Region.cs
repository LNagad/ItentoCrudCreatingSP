using Domain.Common;

namespace Domain.Entities
{
    public class Region : AuditableBaseEntity
    {
        public required string Name { get; set; }
    }
}
