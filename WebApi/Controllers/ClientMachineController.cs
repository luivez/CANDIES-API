using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using WebApi.Entities;
using WebApi.Repository;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Globalization;

namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/clienteMaquina/")]
    public class ClientMachineController : ControllerBase
    {
        private IClientMachineRepository _clientMachineRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public ClientMachineController(IClientMachineRepository clientMachineRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _clientMachineRepository = clientMachineRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]ClientMachineDto clientMachineDto)
        {
            var clientMachine = _mapper.Map<ClientMachine>(clientMachineDto);  // Mapear dto a entitidad
            clientMachine.dateAssignment = DateTime.ParseExact(clientMachineDto.dateAssignment, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            try
            {
                clientMachine = _clientMachineRepository.Insert(clientMachine); // Guardamos el elemento
                clientMachineDto = _mapper.Map<ClientMachineDto>(clientMachine);  // Mapear entitidad a dto
                return Ok(clientMachineDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var clientMachines =  _clientMachineRepository.GetAll(); // Listamos elementos
            var clientMachineDtos = _mapper.Map<IList<ClientMachineDto>>(clientMachines); // Mapear entitidad a dto
            return Ok(clientMachineDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var clientMachine =  _clientMachineRepository.GetById(id); // Buscamos el elemento
            var clientMachineDto = _mapper.Map<ClientMachineDto>(clientMachine); // Mapear entitidad a dto
            return Ok(clientMachineDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]ClientMachineDto clientMachineDto)
        {
            var clientMachine = _mapper.Map<ClientMachine>(clientMachineDto); // Mapear dto a entitidad

            try
            {
                clientMachine =  _clientMachineRepository.Update(clientMachineDto); // Actualizamos el elemento
                clientMachineDto = _mapper.Map<ClientMachineDto>(clientMachine); // Mapear entitidad a dto
                return Ok(clientMachineDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var clientMachine = _clientMachineRepository.Delete(id); // Eliminar elemento
            var clientMachineDto = _mapper.Map<ClientMachineDto>(clientMachine); // Mapear entitidad a dto
            return Ok(clientMachineDto);
        }
    }
}
