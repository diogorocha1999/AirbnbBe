using System.Collections.Generic;

namespace AirbnbAPI.Data
{
    public class Property
    {
        public int Id { get; set; } // Chave primária
        public string Name { get; set; } // Nome da propriedade
        public string Location { get; set; } // Localização da propriedade
        public decimal PricePerNight { get; set; } // Preço por noite
        public List<Booking> Bookings { get; set; } = new List<Booking>(); // Relação 1:N com a tabela Bookings
    }
}