using Microsoft.EntityFrameworkCore;

namespace AirbnbAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tabela de usuários no banco de dados
        public DbSet<User> Users { get; set; }

        // Tabela de propriedades no banco de dados
        public DbSet<Property> Properties { get; set; }

        // Tabela de reservas no banco de dados
        public DbSet<Booking> Bookings { get; set; }
    }
}