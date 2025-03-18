using System.ComponentModel.DataAnnotations;

namespace AirbnbAPI.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "O email é obrigatório.")] // Validação: O campo Email é obrigatório
        [EmailAddress(ErrorMessage = "Email inválido.")] // Validação: O campo Email deve ser um email válido
        public string Email { get; set; } // Email do usuário

        [Required(ErrorMessage = "A senha é obrigatória.")] // Validação: O campo Password é obrigatório
        public string Password { get; set; } // Senha do usuário
    }
}