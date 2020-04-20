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
    [Route("api/maquina/")]
    public class MachineController : ControllerBase
    {
        private IMachineRepository _machineRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public MachineController(IMachineRepository machineRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _machineRepository = machineRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]MachineDto machineDto)
        {
            var machine = _mapper.Map<Machine>(machineDto);  // Mapear dto a entitidad

            try
            {
                machine = _machineRepository.Insert(machine); // Guardamos el elemento
                machineDto = _mapper.Map<MachineDto>(machine);  // Mapear entitidad a dto
                return Ok(machineDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var machines =  _machineRepository.GetAll(); // Listamos elementos
            var machineDtos = _mapper.Map<IList<MachineDto>>(machines); // Mapear entitidad a dto
            return Ok(machineDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var machine =  _machineRepository.GetById(id); // Buscamos el elemento
            var machineDto = _mapper.Map<MachineDto>(machine); // Mapear entitidad a dto
            return Ok(machineDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]MachineDto machineDto)
        {
            var machine = _mapper.Map<Machine>(machineDto); // Mapear dto a entitidad

            try
            {
                machine =  _machineRepository.Update(machineDto); // Actualizamos el elemento
                machineDto = _mapper.Map<MachineDto>(machine); // Mapear entitidad a dto
                return Ok(machineDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var machine = _machineRepository.Delete(id); // Eliminar elemento
            var machineDto = _mapper.Map<MachineDto>(machine); // Mapear entitidad a dto
            return Ok(machineDto);
        }
    }
}
