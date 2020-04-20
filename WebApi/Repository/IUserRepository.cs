using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Repository
{
    // Repositorio para metodos personalizados
    public interface IUserRepository : IRepository<User, UserDto>
    {
        User Authenticate(string userName, string password);
        User Create(User user, string password);
    }
}