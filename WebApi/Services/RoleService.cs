using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class RoleService : IRoleRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public RoleService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<Role> GetAll()
        {
            List<Role> roles = _context.Role.ToList();
            List<Role> roles2 = _context.Role.ToList();
            foreach (Role role in roles)
            {
                if (role.state == false)
                {
                    // Eliminar elementos inactivos
                    roles2.Remove(role);
                }
            }
            return roles2;
        }

        // Obtener elemento especifico
        public Role GetById(int id)
        {
            return _context.Role.Find(id);
        }

        // Insertar elementos en la base de datos
        public Role Insert(Role role)
        {
            // Validar si ya existe
            if (_context.Role.Any(x => x.description == role.description))
                throw new AppException("El rol \"" + role.description + "\" ya existe.");

            // Guardar elemento
            _context.Role.Add(role);
            _context.SaveChanges();
            return role;
        }

        // Actualizar elemento
        public Role Update(RoleDto roleParam)
        {
            // Buscamos elemento a modificar
            var role = _context.Role.Find(roleParam.idRole);

            // verificamos q existe
            if (role == null)
                throw new AppException("Rol no existe.");

            // Verificamos si los datos ya existen
            if (roleParam.description != role.description)
            {
                // roleName has changed so check if the new roleName is already taken
                if (_context.Role.Any(x => x.description == roleParam.description))
                    throw new AppException("El role " + roleParam.description + " ya existe");
            }

            // actualizamos dato
            role.update(roleParam, _context);

            // Guardar cambios
            _context.Role.Update(role);
            _context.SaveChanges();
            return role;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public Role Delete(int id)
        {
            // Buscamos elemento a eliminar
            var role = _context.Role.Find(id);

            // verificamos que el elemnto existe
            if (role == null || role.state == false)
            {
                throw new AppException("Rol no existe.");
            }

            // cambiamos estado
            role.state = false;

            // Guardamos cambios
            _context.Role.Update(role);
            _context.SaveChanges();
            return role;
        }
    }
}