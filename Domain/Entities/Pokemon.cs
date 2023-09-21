

using Domain.Common;

namespace Domain.Entities
{
    public class Pokemon: AuditableBaseEntity
    {
        public required string Name { get; set; }
        public required string PokemonPhotoURL { get; set; }
        public required int RegionId { get; set; }
        public required int PrimaryTypeId { get; set; }
        public required int SecondaryTypeId { get; set; }

    }
}
