using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class PurchaseOrderService : IPurchaseOrderRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public PurchaseOrderService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<PurchaseOrder> GetAll()
        {
            return _context.PurchaseOrder;
        }

        // Obtener elemento especifico
        public PurchaseOrder GetById(int id)
        {
            return _context.PurchaseOrder.Find(id);
        }

        // Insertar elementos en la base de datos
        public PurchaseOrder Insert(PurchaseOrder purchaseOrder)
        {
            // Validar si ya existe
            if (_context.PurchaseOrder.Any(x => x.orderTitle == purchaseOrder.orderTitle))
                throw new AppException("La orden de compra \"" + purchaseOrder.orderTitle + "\" ya existe.");
            purchaseOrder.datePurchaseOrder = DateTime.Now;
            // Guardar elemento
            _context.PurchaseOrder.Add(purchaseOrder);
            _context.SaveChanges();
            return purchaseOrder;
        }

        // Actualizar elemento
        public PurchaseOrder Update(PurchaseOrderDto purchaseOrderParam)
        {
            // Buscamos elemento a modificar
            var purchaseOrder = _context.PurchaseOrder.Find(purchaseOrderParam.idPurchaseOrder);

            // verificamos q existe
            if (purchaseOrder == null)
                throw new AppException("Orden de compra no existe.");

            // Verificamos si los datos ya existen
            if (purchaseOrderParam.orderTitle != purchaseOrder.orderTitle)
            {
                // purchaseOrderName has changed so check if the new purchaseOrderName is already taken
                if (_context.PurchaseOrder.Any(x => x.orderTitle == purchaseOrderParam.orderTitle))
                    throw new AppException("La orden de compra " + purchaseOrderParam.orderTitle + " ya existe");
            }

            // actualizamos dato
            purchaseOrder.update(purchaseOrderParam, _context);

            // Guardar cambios
            _context.PurchaseOrder.Update(purchaseOrder);
            _context.SaveChanges();
            return purchaseOrder;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public PurchaseOrder Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}