using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Dtos;
using WebApi.Repository;

namespace WebApi.Services
{
    public class PersonService : IPersonRepository
    {
        // Agregamos contexto de la base de datos
        private DataContext _context;

        // Constructor con contexto
        public PersonService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos activos de la base de datos
        public IEnumerable<Person> GetAll()
        {
            List<Person> persons = _context.Person.ToList();
            List<Person> persons2 = _context.Person.ToList();
            foreach (Person person in persons)
            {
                if (person.state == false)
                {
                    // Eliminar elementos inactivos
                    persons2.Remove(person);
                }
            }
            return persons2;
        }

        // Obtener elemento especifico
        public Person GetById(int id)
        {
            return _context.Person.Find(id);
        }

        // Insertar elementos en la base de datos
        public Person Insert(Person person)
        {
            // Validar si ya existe
            if (_context.Person.Any(x => x.name == person.name))
                throw new AppException("El rol \"" + person.name + "\" ya existe.");

            // Guardar elemento
            _context.Person.Add(person);
            _context.SaveChanges();
            return person;
        }

        // Actualizar elemento
        public Person Update(PersonDto personParam)
        {
            // Buscamos elemento a modificar
            var person = _context.Person.Find(personParam.idPerson);

            // verificamos q existe
            if (person == null)
                throw new AppException("Persona no existe.");

            // Verificamos si los datos ya existen
            if (personParam.name != person.name)
            {
                // personName has changed so check if the new personName is already taken
                if (_context.Person.Any(x => x.name == personParam.name))
                    throw new AppException("La persona " + personParam.name + " ya existe");
            }

            // actualizamos dato
            person.update(personParam);

            // Guardar cambios
            _context.Person.Update(person);
            _context.SaveChanges();
            return person;
        }

        // Eliminar elemento (Cambiar a inactivo)
        public Person Delete(int id)
        {
            // Buscamos elemento a eliminar
            var person = _context.Person.Find(id);

            // verificamos que el elemnto existe
            if (person == null || person.state == false)
            {
                throw new AppException("Persona no existe.");
            }

            // cambiamos estado
            person.state = false;

            // Guardamos cambios
            _context.Person.Update(person);
            _context.SaveChanges();
            return person;
        }
    }
}