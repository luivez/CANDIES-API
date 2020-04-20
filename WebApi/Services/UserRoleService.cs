using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class UserRoleService : IUserRoleRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public UserRoleService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<UserRole> GetAll()
        {
            List<UserRole> userRoles = _context.UserRole.ToList();
            List<UserRole> userRoles2 = _context.UserRole.ToList();
            foreach (UserRole userRole in userRoles)
            {
                if (userRole.state == false)
                {
                    // Eliminar elementos inactivos
                    userRoles2.Remove(userRole);
                }
            }
            return userRoles2;
        }

        // Obtener elemento especifico
        public UserRole GetById(int id)
        {
            return _context.UserRole.Find(id);
        }

        // Insertar elementos en la base de datos
        public UserRole Insert(UserRole userRole)
        {
            // Guardar elemento
            _context.UserRole.Add(userRole);
            _context.SaveChanges();
            return userRole;
        }

        // Actualizar elemento
        public UserRole Update(UserRoleDto userRoleParam)
        {
            // Buscamos elemento a modificar
            var userRole = _context.UserRole.Find(userRoleParam.idRole);

            // verificamos q existe
            if (userRole == null)
                throw new AppException("Usuario-rol no existe.");

            // actualizamos dato
            userRole.update(userRoleParam, _context);

            // Guardar cambios
            _context.UserRole.Update(userRole);
            _context.SaveChanges();
            return userRole;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public UserRole Delete(int id)
        {
            // Buscamos elemento a eliminar
            var userRole = _context.UserRole.Find(id);

            // verificamos que el elemnto existe
            if (userRole == null || userRole.state == false)
            {
                throw new AppException("UsuarioRol no existe.");
            }

            // cambiamos estado
            userRole.state = false;

            // Guardamos cambios
            _context.UserRole.Update(userRole);
            _context.SaveChanges();
            return userRole;
        }
    }
}