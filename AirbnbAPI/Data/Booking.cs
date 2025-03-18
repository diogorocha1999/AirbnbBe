using System;

namespace AirbnbAPI.Data
{
    public class Booking
    {
        public int Id { get; set; } // Chave primária
        public DateTime CheckInDate { get; set; } // Data de check-in
        public DateTime CheckOutDate { get; set; } // Data de check-out
        public int UserId { get; set; } // Chave estrangeira para a tabela Users
        public User User { get; set; } // Relação com a tabela Users
        public int PropertyId { get; set; } // Chave estrangeira para a tabela Properties
        public Property Property { get; set; } // Relação com a tabela Properties
    }
}