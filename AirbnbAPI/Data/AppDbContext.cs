using Microsoft.EntityFrameworkCore;

namespace AirbnbAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        // Tabela de usuários no banco de dados
        public DbSet<User> Users { get; set; }

        // Tabela de propriedades no banco de dados
        public DbSet<Property> Properties { get; set; }

        // Tabela de reservas no banco de dados
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar precisão para PricePerNight
            modelBuilder.Entity<Property>()
                .Property(p => p.PricePerNight)
                .HasColumnType("decimal(18,2)"); // Define precisão e escala
        }
    }
}