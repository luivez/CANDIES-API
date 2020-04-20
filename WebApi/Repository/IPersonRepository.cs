using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Repository
{
    // Repositorio para metodos personalizados
    public interface IPersonRepository : IRepository<Person,PersonDto>
    {

    }
}