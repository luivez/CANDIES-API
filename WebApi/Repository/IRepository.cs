using System.Collections.Generic;

namespace WebApi.Repository
{
    // Repositorio base con metodos CRUD
    public interface IRepository<T,D>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Insert(T body);
        T Update(D body);
        T Delete(int id);
    }
}