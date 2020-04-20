using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Repository;

namespace WebApi.Services
{
    public class ProductService : IProductRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public ProductService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<Product> GetAll()
        {
            List<Product> products = _context.Product.ToList();
            List<Product> products2 = _context.Product.ToList();
            foreach (Product product in products)
            {
                if (product.state == false)
                {
                    // Eliminar elementos inactivos
                    products2.Remove(product);
                }
            }
            return products2;
        }

        // Obtener elemento especifico
        public Product GetById(int id)
        {
            return _context.Product.Find(id);
        }

        // Insertar elementos en la base de datos
        public Product Insert(Product product)
        {
            // Validar si ya existe
            if (_context.Product.Any(x => x.name == product.name))
                throw new AppException("El product \"" + product.name + "\" ya existe.");

            // Guardar elemento
            _context.Product.Add(product);
            _context.SaveChanges();
            return product;
        }

        // Actualizar elemento
        public Product Update(ProductDto productParam)
        {
            // Buscamos elemento a modificar
            var product = _context.Product.Find(productParam.idProduct);

            // verificamos q existe
            if (product == null)
                throw new AppException("Producto no existe.");

            // Verificamos si los datos ya existen
            if (productParam.name != product.name)
            {
                // productName has changed so check if the new productName is already taken
                if (_context.Product.Any(x => x.name == productParam.name))
                    throw new AppException("El producto " + productParam.name + " ya existe");
            }

            // actualizamos dato
            product.update(productParam, _context);

            // Guardar cambios
            _context.Product.Update(product);
            _context.SaveChanges();
            return product;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public Product Delete(int id)
        {
            // Buscamos elemento a eliminar
            var product = _context.Product.Find(id);

            // verificamos que el elemnto existe
            if (product == null || product.state == false)
            {
                throw new AppException("Producto no existe.");
            }

            // cambiamos estado
            product.state = false;

            // Guardamos cambios
            _context.Product.Update(product);
            _context.SaveChanges();
            return product;
        }
    }
}