using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AirbnbAPI.Business;
using AirbnbAPI.Data;
using AirbnbAPI.Models;

namespace AirbnbAPI.Controllers
{
    [Route("api/[controller]")] // Define a rota base para o controller (api/users)
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/users/register
        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] User user)
        {
            var newUser = _userService.Register(user); // Registra um novo usuário
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser); // Retorna 201 (Created) com o usuário criado
        }

        // POST: api/users/login
        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] LoginRequest request)
        {
            var token = _userService.Login(request.Email, request.Password); // Faz login e gera um token JWT
            if (token == null)
            {
                return Unauthorized(); // Retorna 401 (Unauthorized) se o login falhar
            }
            return Ok(token); // Retorna o token JWT
        }

        // GET: api/users/5
        [Authorize] // Protege o endpoint com autenticação JWT
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userService.GetUserById(id); // Busca o usuário pelo ID
            if (user == null)
            {
                return NotFound(); // Retorna 404 (Not Found) se o usuário não for encontrado
            }
            return user; // Retorna o usuário encontrado
        }
    }
}