using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class ClientService : IClientRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public ClientService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<Client> GetAll()
        {
            List<Client> clients = _context.Client.ToList();
            List<Client> clients2 = _context.Client.ToList();
            foreach (Client client in clients)
            {
                if (client.state == false)
                {
                    // Eliminar elementos inactivos
                    clients2.Remove(client);
                }
            }
            return clients2;
        }

        // Obtener elemento especifico
        public Client GetById(int id)
        {
            return _context.Client.Find(id);
        }

        // Insertar elementos en la base de datos
        public Client Insert(Client client)
        {
            // Validar si ya existe
            if (_context.Client.Any(x => x.name == client.name))
                throw new AppException("El cliente \"" + client.name + "\" ya existe.");

            // Guardar elemento
            _context.Client.Add(client);
            _context.SaveChanges();
            return client;
        }

        // Actualizar elemento
        public Client Update(ClientDto clientParam)
        {
            // Buscamos elemento a modificar
            var client = _context.Client.Find(clientParam.idClient);

            // verificamos q existe
            if (client == null)
                throw new AppException("Cliente no existe.");

            // Verificamos si los datos ya existen
            if (clientParam.name != client.name)
            {
                // clientName has changed so check if the new clientName is already taken
                if (_context.Client.Any(x => x.name == clientParam.name))
                    throw new AppException("El cliente " + clientParam.name + " ya existe");
            }

            // actualizamos dato
            client.update(clientParam, _context);

            // Guardar cambios
            _context.Client.Update(client);
            _context.SaveChanges();
            return client;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public Client Delete(int id)
        {
            // Buscamos elemento a eliminar
            var client = _context.Client.Find(id);

            // verificamos que el elemnto existe
            if (client == null || client.state == false)
            {
                throw new AppException("Cliente no existe.");
            }

            // cambiamos estado
            client.state = false;

            // Guardamos cambios
            _context.Client.Update(client);
            _context.SaveChanges();
            return client;
        }
    }
}