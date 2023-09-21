

using Domain.Common;

namespace Domain.Entities
{
    public class PokemonType: AuditableBaseEntity
    {
        public required string Name { get; set; }
    }
}
