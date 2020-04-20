using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class PurchaseDetailService : IPurchaseDetailRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public PurchaseDetailService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<PurchaseDetail> GetAll()
        {
            return _context.PurchaseDetail;
        }

        // Obtener elemento especifico
        public PurchaseDetail GetById(int id)
        {
            return _context.PurchaseDetail.Find(id);
        }

        // Insertar elementos en la base de datos
        public PurchaseDetail Insert(PurchaseDetail purchaseDetail)
        {
            // Guardar elemento
            _context.PurchaseDetail.Add(purchaseDetail);
            _context.SaveChanges();
            return purchaseDetail;
        }

        // Actualizar elemento
        public PurchaseDetail Update(PurchaseDetailDto purchaseDetailParam)
        {
            // Buscamos elemento a modificar
            var purchaseDetail = _context.PurchaseDetail.Find(purchaseDetailParam.idPurchaseDetail);

            // verificamos q existe
            if (purchaseDetail == null)
                throw new AppException("Rol no existe.");

            // actualizamos dato
            purchaseDetail.update(purchaseDetailParam, _context);

            // Guardar cambios
            _context.PurchaseDetail.Update(purchaseDetail);
            _context.SaveChanges();
            return purchaseDetail;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public PurchaseDetail Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}