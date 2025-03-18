using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AirbnbAPI.Business;
using AirbnbAPI.Data;

namespace AirbnbAPI.Controllers
{
    [Route("api/[controller]")] // Define a rota base para o controller (api/bookings)
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // POST: api/bookings
        [Authorize] // Protege o endpoint com autenticação JWT
        [HttpPost]
        public ActionResult<Booking> BookProperty([FromBody] BookingRequest request)
        {
            try
            {
                var booking = _bookingService.BookProperty(request.UserId, request.PropertyId, request.CheckInDate, request.CheckOutDate); // Cria uma nova reserva
                return CreatedAtAction(nameof(GetBookingById), new { id = booking.Id }, booking); // Retorna 201 (Created) com a reserva criada
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Retorna 400 (Bad Request) se houver erro de validação
            }
        }

        // GET: api/bookings/user/5
        [Authorize] // Protege o endpoint com autenticação JWT
        [HttpGet("user/{userId}")]
        public ActionResult<List<Booking>> GetUserBookings(int userId)
        {
            var bookings = _bookingService.GetUserBookings(userId); // Retorna todas as reservas de um utilizador
            return bookings;
        }

        // GET: api/bookings/5
        [Authorize] // Protege o endpoint com autenticação JWT
        [HttpGet("{id}")]
        public ActionResult<Booking> GetBookingById(int id)
        {
            var booking = _bookingService.GetBookingById(id); // Busca uma reserva pelo ID
            if (booking == null)
            {
                return NotFound(); // Retorna 404 (Not Found) se a reserva não for encontrada
            }
            return booking; // Retorna a reserva encontrada
        }

        // DELETE: api/bookings/5
        [Authorize] // Protege o endpoint com autenticação JWT
        [HttpDelete("{id}")]
        public ActionResult CancelBooking(int id)
        {
            _bookingService.CancelBooking(id); // Cancela uma reserva pelo ID
            return NoContent(); // Retorna 204 (No Content) para indicar sucesso sem retorno
        }
    }

    // Classe para representar a requisição de reserva
    public class BookingRequest
    {
        public int UserId { get; set; } // ID do utilizador que está fazendo a reserva
        public int PropertyId { get; set; } // ID da propriedade que está sendo reservada
        public DateTime CheckInDate { get; set; } // Data de check-in
        public DateTime CheckOutDate { get; set; } // Data de check-out
    }
}