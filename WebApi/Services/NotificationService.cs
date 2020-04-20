using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class NotificationService : INotificationRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public NotificationService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<Notification> GetAll()
        {
            return _context.Notification;
        }

        // Obtener elemento especifico
        public Notification GetById(int id)
        {
            return _context.Notification.Find(id);
        }

        // Insertar elementos en la base de datos
        public Notification Insert(Notification notif)
        {
            // Guardar elemento
            _context.Notification.Add(notif);
            _context.SaveChanges();
            return notif;
        }

        // Actualizar elemento
        public Notification Update(NotificationDto notifParam)
        {
            // Buscamos elemento a modificar
            var notif = _context.Notification.Find(notifParam.idNotification);

            // verificamos q existe
            if (notif == null)
                throw new AppException("Notificacion no existe.");

            // actualizamos dato
            notif.update(notifParam, _context);

            // Guardar cambios
            _context.Notification.Update(notif);
            _context.SaveChanges();
            return notif;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public Notification Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}