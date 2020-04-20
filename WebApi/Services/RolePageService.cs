using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class RolePageService : IRolePageRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public RolePageService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<RolePage> GetAll()
        {
            List<RolePage> rolePages = _context.RolePage.ToList();
            List<RolePage> rolePages2 = _context.RolePage.ToList();
            foreach (RolePage rolePage in rolePages)
            {
                if (rolePage.state == false)
                {
                    // Eliminar elementos inactivos
                    rolePages2.Remove(rolePage);
                }
            }
            return rolePages2;
        }

        // Obtener elemento especifico
        public RolePage GetById(int id)
        {
            return _context.RolePage.Find(id);
        }

        // Insertar elementos en la base de datos
        public RolePage Insert(RolePage rolePage)
        {
            // Guardar elemento
            _context.RolePage.Add(rolePage);
            _context.SaveChanges();
            return rolePage;
        }

        // Actualizar elemento
        public RolePage Update(RolePageDto rolePageParam)
        {
            // Buscamos elemento a modificar
            var rolePage = _context.RolePage.Find(rolePageParam.idRole);

            // verificamos q existe
            if (rolePage == null)
                throw new AppException("Rol no existe.");

            // actualizamos dato
            rolePage.update(rolePageParam, _context);

            // Guardar cambios
            _context.RolePage.Update(rolePage);
            _context.SaveChanges();
            return rolePage;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public RolePage Delete(int id)
        {
            // Buscamos elemento a eliminar
            var rolePage = _context.RolePage.Find(id);

            // verificamos que el elemnto existe
            if (rolePage == null || rolePage.state == false)
            {
                throw new AppException("UsuarioRol no existe.");
            }

            // cambiamos estado
            rolePage.state = false;

            // Guardamos cambios
            _context.RolePage.Update(rolePage);
            _context.SaveChanges();
            return rolePage;
        }
    }
}