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
    [Route("api/operacionProductoSalida/")]
    public class OperationProductOutputController : ControllerBase
    {
        private IOperationProductOutputRepository _opOutputRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public OperationProductOutputController(IOperationProductOutputRepository opOutputRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _opOutputRepository = opOutputRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]OperationProductOutputDto opOutputDto)
        {
            var opOutput = _mapper.Map<OperationProductOutput>(opOutputDto);  // Mapear dto a entitidad

            try
            {
                opOutput = _opOutputRepository.Insert(opOutput); // Guardamos el elemento
                opOutputDto = _mapper.Map<OperationProductOutputDto>(opOutput);  // Mapear entitidad a dto
                return Ok(opOutputDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var opOutputs =  _opOutputRepository.GetAll(); // Listamos elementos
            var opOutputDtos = _mapper.Map<IList<OperationProductOutputDto>>(opOutputs); // Mapear entitidad a dto
            return Ok(opOutputDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var opOutput =  _opOutputRepository.GetById(id); // Buscamos el elemento
            var opOutputDto = _mapper.Map<OperationProductOutputDto>(opOutput); // Mapear entitidad a dto
            return Ok(opOutputDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]OperationProductOutputDto opOutputDto)
        {
            var opOutput = _mapper.Map<OperationProductOutput>(opOutputDto); // Mapear dto a entitidad

            try
            {
                opOutput =  _opOutputRepository.Update(opOutputDto); // Actualizamos el elemento
                opOutputDto = _mapper.Map<OperationProductOutputDto>(opOutput); // Mapear entitidad a dto
                return Ok(opOutputDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var opOutput = _opOutputRepository.Delete(id); // Eliminar elemento
            var opOutputDto = _mapper.Map<OperationProductOutputDto>(opOutput); // Mapear entitidad a dto
            return Ok(opOutputDto);
        }
    }
}
