using Microsoft.EntityFrameworkCore;

namespace Ejemplo01.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {

        }

        public DbSet<Amigo> Amigos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amigo>().HasData(new Amigo {
                Id = 1, 
                Nombre = "Chris", 
                Email ="correo@outlook.com", 
                Ciudad = Provincia.Lima
            });
        }
    }
}