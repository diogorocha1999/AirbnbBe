using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using AirbnbAPI.Data;

namespace AirbnbAPI.Business
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public User Register(User user)
        {
            // Hash da senha antes de salvar no banco de dados
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            // Adiciona o usuário ao contexto do banco de dados
            _context.Users.Add(user);

            // Salva as alterações no banco de dados
            _context.SaveChanges();

            // Retorna o usuário criado
            return user;
        }

        public string Login(string email, string password)
        {
            // Busca o usuário pelo email
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            // Verifica se o usuário existe e se a senha está correta
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null; // Login falhou (usuário não encontrado ou senha incorreta)

            // Gera e retorna um token JWT para o usuário
            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); // Cria um manipulador de tokens JWT
            var key = Encoding.ASCII.GetBytes("SuaChaveSecretaSuperSecreta123!"); // Converte a chave secreta para bytes

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Adiciona o ID do usuário ao token
                    new Claim(ClaimTypes.Email, user.Email) // Adiciona o email do usuário ao token
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Define a expiração do token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // Define as credenciais de assinatura
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); // Cria o token
            return tokenHandler.WriteToken(token); // Retorna o token como uma string
        }

        public User GetUserById(int id)
        {
            // Busca o usuário no banco de dados
            return _context.Users.FirstOrDefault(u => u.Id == id) ?? throw new KeyNotFoundException("User not found");
        }
    }
}