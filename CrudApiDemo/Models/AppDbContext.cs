using Microsoft.EntityFrameworkCore;

namespace CrudApiDemo.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para el campo Precio
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");
        }

        public DbSet<Producto> Productos => Set<Producto>();
    }
}
