using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using WebApi.Entities;
using WebApi.Repository;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/persona/")]
    public class PersonController : ControllerBase
    {
        private IPersonRepository _personRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public PersonController(IPersonRepository personRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);  // Mapear dto a entitidad

            try
            {
                person = _personRepository.Insert(person); // Guardamos el elemento
                personDto = _mapper.Map<PersonDto>(person);  // Mapear entitidad a dto
                return Ok(personDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var persons =  _personRepository.GetAll(); // Listamos elementos
            var personDtos = _mapper.Map<IList<PersonDto>>(persons); // Mapear entitidad a dto
            return Ok(personDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var person =  _personRepository.GetById(id); // Buscamos el elemento
            var personDto = _mapper.Map<PersonDto>(person); // Mapear entitidad a dto
            return Ok(personDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto); // Mapear dto a entitidad

            try
            {
                person =  _personRepository.Update(personDto); // Actualizamos el elemento
                personDto = _mapper.Map<PersonDto>(person); // Mapear entitidad a dto
                return Ok(personDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var person = _personRepository.Delete(id); // Eliminar elemento
            var personDto = _mapper.Map<PersonDto>(person); // Mapear entitidad a dto
            return Ok(personDto);
        }
    }
}
