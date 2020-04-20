using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Repository
{
    // Repositorio para metodos personalizados
    public interface IClientRepository : IRepository<Client,ClientDto>
    {

    }
}