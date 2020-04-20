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
    [Route("api/cliente/")]
    public class ClientController : ControllerBase
    {
        private IClientRepository _clientRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public ClientController(IClientRepository clientRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);  // Mapear dto a entitidad

            try
            {
                client = _clientRepository.Insert(client); // Guardamos el elemento
                clientDto = _mapper.Map<ClientDto>(client);  // Mapear entitidad a dto
                return Ok(clientDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var clients =  _clientRepository.GetAll(); // Listamos elementos
            var clientDtos = _mapper.Map<IList<ClientDto>>(clients); // Mapear entitidad a dto
            return Ok(clientDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var client =  _clientRepository.GetById(id); // Buscamos el elemento
            var clientDto = _mapper.Map<ClientDto>(client); // Mapear entitidad a dto
            return Ok(clientDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto); // Mapear dto a entitidad

            try
            {
                client =  _clientRepository.Update(clientDto); // Actualizamos el elemento
                clientDto = _mapper.Map<ClientDto>(client); // Mapear entitidad a dto
                return Ok(clientDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var client = _clientRepository.Delete(id); // Eliminar elemento
            var clientDto = _mapper.Map<ClientDto>(client); // Mapear entitidad a dto
            return Ok(clientDto);
        }
    }
}
