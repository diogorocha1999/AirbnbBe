using System;
using System.Collections.Generic;
using System.Linq;
using AirbnbAPI.Data;

namespace AirbnbAPI.Business
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public Booking BookProperty(int userId, int propertyId, DateTime checkIn, DateTime checkOut)
        {
            // Valida as datas de check-in e check-out
            if (checkIn >= checkOut)
            {
                throw new ArgumentException("A data de check-in deve ser anterior à data de check-out.");
            }

            var booking = new Booking
            {
                UserId = userId, // Define o ID do utilizador
                PropertyId = propertyId, // Define o ID da propriedade
                CheckInDate = checkIn, // Define a data de check-in
                CheckOutDate = checkOut // Define a data de check-out
            };

            _context.Bookings.Add(booking); // Adiciona a reserva ao banco de dados
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return booking; // Retorna a reserva criada
        }

        public List<Booking> GetUserBookings(int userId)
        {
            return _context.Bookings.Where(b => b.UserId == userId).ToList(); // Retorna todas as reservas de um utilizador
        }

        public Booking GetBookingById(int id)
        {
            return _context.Bookings.FirstOrDefault(b => b.Id == id); // Retorna uma reserva pelo ID
        }

        public void CancelBooking(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id); // Busca a reserva pelo ID
            if (booking != null)
            {
                _context.Bookings.Remove(booking); // Remove a reserva
                _context.SaveChanges(); // Salva as alterações no banco de dados
            }
        }
    }
}