using AirbnbAPI.Data;

namespace AirbnbAPI.Business
{
    public interface IUserService
    {
        User Register(User user); // Registra um novo usuário
        string Login(string email, string password); // Faz login e retorna um token JWT
        User GetUserById(int id); // Retorna um usuário pelo ID
    }
}