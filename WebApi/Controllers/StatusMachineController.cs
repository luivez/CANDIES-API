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
    [Route("api/estatusMaquina/")]
    public class StatusMachineController : ControllerBase
    {
        private IStatusMachineRepository _statusMachineRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public StatusMachineController(IStatusMachineRepository statusMachineRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _statusMachineRepository = statusMachineRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]StatusMachineDto statusMachineDto)
        {
            var statusMachine = _mapper.Map<StatusMachine>(statusMachineDto);  // Mapear dto a entitidad

            try
            {
                statusMachine = _statusMachineRepository.Insert(statusMachine); // Guardamos el elemento
                statusMachineDto = _mapper.Map<StatusMachineDto>(statusMachine);  // Mapear entitidad a dto
                return Ok(statusMachineDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var statusMachines =  _statusMachineRepository.GetAll(); // Listamos elementos
            var statusMachineDtos = _mapper.Map<IList<StatusMachineDto>>(statusMachines); // Mapear entitidad a dto
            return Ok(statusMachineDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var statusMachine =  _statusMachineRepository.GetById(id); // Buscamos el elemento
            var statusMachineDto = _mapper.Map<StatusMachineDto>(statusMachine); // Mapear entitidad a dto
            return Ok(statusMachineDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]StatusMachineDto statusMachineDto)
        {
            var statusMachine = _mapper.Map<StatusMachine>(statusMachineDto); // Mapear dto a entitidad

            try
            {
                statusMachine =  _statusMachineRepository.Update(statusMachineDto); // Actualizamos el elemento
                statusMachineDto = _mapper.Map<StatusMachineDto>(statusMachine); // Mapear entitidad a dto
                return Ok(statusMachineDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var statusMachine = _statusMachineRepository.Delete(id); // Eliminar elemento
            var statusMachineDto = _mapper.Map<StatusMachineDto>(statusMachine); // Mapear entitidad a dto
            return Ok(statusMachineDto);
        }
    }
}
