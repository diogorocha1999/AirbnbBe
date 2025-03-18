using System;
using System.Collections.Generic;
using AirbnbAPI.Data;

namespace AirbnbAPI.Business
{
    public interface IBookingService
    {
        Booking BookProperty(int userId, int propertyId, DateTime checkIn, DateTime checkOut); // Cria uma nova reserva
        List<Booking> GetUserBookings(int userId); // Retorna todas as reservas de um utilizador
        Booking GetBookingById(int id); // Retorna uma reserva pelo ID
        void CancelBooking(int id); // Cancela uma reserva pelo ID
    }
}