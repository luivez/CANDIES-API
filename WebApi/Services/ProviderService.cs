using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class ProviderService : IProviderRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public ProviderService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<Provider> GetAll()
        {
            List<Provider> providers = _context.Provider.ToList();
            List<Provider> providers2 = _context.Provider.ToList();
            foreach (Provider provider in providers)
            {
                if (provider.state == false)
                {
                    // Eliminar elementos inactivos
                    providers2.Remove(provider);
                }
            }
            return providers2;
        }

        // Obtener elemento especifico
        public Provider GetById(int id)
        {
            return _context.Provider.Find(id);
        }

        // Insertar elementos en la base de datos
        public Provider Insert(Provider provider)
        {
            // Validar si ya existe
            if (_context.Provider.Any(x => x.nameProvider == provider.nameProvider))
                throw new AppException("El proveedor \"" + provider.nameProvider + "\" ya existe.");

            // Guardar elemento
            _context.Provider.Add(provider);
            _context.SaveChanges();
            return provider;
        }

        // Actualizar elemento
        public Provider Update(ProviderDto providerParam)
        {
            // Buscamos elemento a modificar
            var provider = _context.Provider.Find(providerParam.idProvider);

            // verificamos q existe
            if (provider == null)
                throw new AppException("Proveedor no existe.");

            // Verificamos si los datos ya existen
            if (providerParam.nameProvider != provider.nameProvider)
            {
                // providerName has changed so check if the new providerName is already taken
                if (_context.Provider.Any(x => x.nameProvider == providerParam.nameProvider))
                    throw new AppException("El proveedor " + providerParam.nameProvider + " ya existe");
            }

            // actualizamos dato
            provider.update(providerParam, _context);

            // Guardar cambios
            _context.Provider.Update(provider);
            _context.SaveChanges();
            return provider;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public Provider Delete(int id)
        {
            // Buscamos elemento a eliminar
            var provider = _context.Provider.Find(id);

            // verificamos que el elemnto existe
            if (provider == null || provider.state == false)
            {
                throw new AppException("Rol no existe.");
            }

            // cambiamos estado
            provider.state = false;

            // Guardamos cambios
            _context.Provider.Update(provider);
            _context.SaveChanges();
            return provider;
        }
    }
}