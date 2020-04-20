using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class MachineService : IMachineRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public MachineService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<Machine> GetAll()
        {
            return _context.Machine;
        }

        // Obtener elemento especifico
        public Machine GetById(int id)
        {
            return _context.Machine.Find(id);
        }

        // Insertar elementos en la base de datos
        public Machine Insert(Machine machine)
        {
            // Guardar elemento
            _context.Machine.Add(machine);
            _context.SaveChanges();
            return machine;
        }

        // Actualizar elemento
        public Machine Update(MachineDto machineParam)
        {
            // Buscamos elemento a modificar
            var machine = _context.Machine.Find(machineParam.idMachine);

            // verificamos q existe
            if (machine == null)
                throw new AppException("Maquina no existe.");

            // actualizamos dato
            machine.update(machineParam, _context);

            // Guardar cambios
            _context.Machine.Update(machine);
            _context.SaveChanges();
            return machine;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public Machine Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}