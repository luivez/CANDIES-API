using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class PageService : IPageRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public PageService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<Page> GetAll()
        {
            List<Page> pages = _context.Page.ToList();
            List<Page> pages2 = _context.Page.ToList();
            foreach (Page page in pages)
            {
                if (page.state == false)
                {
                    // Eliminar elementos inactivos
                    pages2.Remove(page);
                }
            }
            return pages2;
        }

        // Obtener elemento especifico
        public Page GetById(int id)
        {
            return _context.Page.Find(id);
        }

        // Insertar elementos en la base de datos
        public Page Insert(Page page)
        {
            // Validar si ya existe
            if (_context.Page.Any(x => x.description == page.description))
                throw new AppException("La pagina \"" + page.description + "\" ya existe.");

            // Guardar elemento
            _context.Page.Add(page);
            _context.SaveChanges();
            return page;
        }

        // Actualizar elemento
        public Page Update(PageDto pageParam)
        {
            // Buscamos elemento a modificar
            var page = _context.Page.Find(pageParam.idPage);

            // verificamos q existe
            if (page == null)
                throw new AppException("Pagina no existe.");

            // Verificamos si los datos ya existen
            if (pageParam.description != page.description)
            {
                // pageName has changed so check if the new pageName is already taken
                if (_context.Page.Any(x => x.description == pageParam.description))
                    throw new AppException("La pagina " + pageParam.description + " ya existe");
            }

            // actualizamos dato
            page.update(pageParam, _context);

            // Guardar cambios
            _context.Page.Update(page);
            _context.SaveChanges();
            return page;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public Page Delete(int id)
        {
            // Buscamos elemento a eliminar
            var page = _context.Page.Find(id);

            // verificamos que el elemnto existe
            if (page == null || page.state == false)
            {
                throw new AppException("Pagina no existe.");
            }

            // cambiamos estado
            page.state = false;

            // Guardamos cambios
            _context.Page.Update(page);
            _context.SaveChanges();
            return page;
        }
    }
}