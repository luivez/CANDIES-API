using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Repository;

namespace WebApi.Services
{
    public class ProductTypeService : IProductTypeRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public ProductTypeService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<ProductType> GetAll()
        {
            return _context.ProductType;
        }

        // Obtener elemento especifico
        public ProductType GetById(int id)
        {
            return _context.ProductType.Find(id);
        }

        // Insertar elementos en la base de datos
        public ProductType Insert(ProductType productType)
        {
            // Validar si ya existe
            if (_context.ProductType.Any(x => x.description == productType.description))
                throw new AppException("El Tipo de producto \"" + productType.description + "\" ya existe.");

            // Guardar elemento
            _context.ProductType.Add(productType);
            _context.SaveChanges();
            return productType;
        }

        // Actualizar elemento
        public ProductType Update(ProductTypeDto productTypeParam)
        {
            // Buscamos elemento a modificar
            var productType = _context.ProductType.Find(productTypeParam.idProductType);

            // verificamos q existe
            if (productType == null)
                throw new AppException("Tipo de producto no existe.");

            // Verificamos si los datos ya existen
            if (productTypeParam.description != productType.description)
            {
                // productTypeName has changed so check if the new productTypeName is already taken
                if (_context.ProductType.Any(x => x.description == productTypeParam.description))
                    throw new AppException("El Tipo de producto " + productTypeParam.description + " ya existe");
            }

            // actualizamos dato
            productType.update(productTypeParam, _context);

            // Guardar cambios
            _context.ProductType.Update(productType);
            _context.SaveChanges();
            return productType;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public ProductType Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}