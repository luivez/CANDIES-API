using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Repository
{
    // Repositorio para metodos personalizados
    public interface IStatusMachineRepository : IRepository<StatusMachine,StatusMachineDto>
    {

    }
}