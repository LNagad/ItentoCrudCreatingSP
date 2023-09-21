using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>().HasKey(p => p.Id);
            modelBuilder.Entity<PokemonType>().HasKey(p => p.Id);
            modelBuilder.Entity<Region>().HasKey(p => p.Id);


            modelBuilder.Entity<Pokemon>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<PokemonType>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Region>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Pokemon>().HasIndex( p => p.Name ).IsUnique();
            modelBuilder.Entity<PokemonType>().HasIndex( p => p.Name ).IsUnique();
            modelBuilder.Entity<Region>().HasIndex( p => p.Name ).IsUnique();


        }
    }
}
