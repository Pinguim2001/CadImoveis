using CadImoveis.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadImoveis.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Proprietario> Proprietarios { get; set; }

        public DbSet<Imovel> Imoveis { get; set; }

        protected override void OnModelCreating(ModelBuilder _modelBuilder)
        {
            _modelBuilder.Entity<Proprietario>()
                .HasMany(p => p.Imoveis)
                .WithOne()
                .HasForeignKey(i => i.IdProprietario)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(_modelBuilder);
        }
    }
}
