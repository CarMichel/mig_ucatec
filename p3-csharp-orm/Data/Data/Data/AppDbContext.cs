using Microsoft.EntityFrameworkCore;
using p3_csharp_orm.Models;

namespace p3_csharp_orm.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Materia> Materias { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.NumeroCelular)
                .IsUnique();

            modelBuilder.Entity<Materia>()
                .HasIndex(m => m.Nombre);
        }
    }
}
