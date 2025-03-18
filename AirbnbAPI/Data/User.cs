using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirbnbAPI.Data
{
    public class User
    {
        public int Id { get; set; } // Chave primária

        [Required(ErrorMessage = "O nome é obrigatório.")] // Validação: O campo Name é obrigatório
        public string Name { get; set; } // Nome do usuário

        [Required(ErrorMessage = "O email é obrigatório.")] // Validação: O campo Email é obrigatório
        [EmailAddress(ErrorMessage = "Email inválido.")] // Validação: O campo Email deve ser um email válido
        public string Email { get; set; } // Email do usuário

        [Required(ErrorMessage = "A senha é obrigatória.")] // Validação: O campo Password é obrigatório
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")] // Validação: A senha deve ter no mínimo 6 caracteres
        public string Password { get; set; } // Senha do usuário

        public List<Booking> Bookings { get; set; } = new List<Booking>(); // Relação 1:N com a tabela Bookings
    }
}