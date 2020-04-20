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
    [Route("api/operacionProductoEntrada/")]
    public class OperationProductEntryController : ControllerBase
    {
        private IOperationProductEntryRepository _operationProductEntryRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public OperationProductEntryController(IOperationProductEntryRepository operationProductEntryRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _operationProductEntryRepository = operationProductEntryRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]OperationProductEntryDto dto)
        {
            var operation = _mapper.Map<OperationProductEntry>(dto);  // Mapear dto a entitidad
            operation.dateOperation = DateTime.ParseExact(dto.dateOperation, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            try
            {
                operation = _operationProductEntryRepository.Insert(operation); // Guardamos el elemento
                dto = _mapper.Map<OperationProductEntryDto>(operation);  // Mapear entitidad a dto
                return Ok(dto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var operationProductEntrys =  _operationProductEntryRepository.GetAll(); // Listamos elementos
            var operationProductEntryDtos = _mapper.Map<IList<OperationProductEntryDto>>(operationProductEntrys); // Mapear entitidad a dto
            return Ok(operationProductEntryDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var operationProductEntry =  _operationProductEntryRepository.GetById(id); // Buscamos el elemento
            var operationProductEntryDto = _mapper.Map<OperationProductEntryDto>(operationProductEntry); // Mapear entitidad a dto
            return Ok(operationProductEntryDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]OperationProductEntryDto operationProductEntryDto)
        {
            var operationProductEntry = _mapper.Map<OperationProductEntry>(operationProductEntryDto); // Mapear dto a entitidad

            try
            {
                operationProductEntry =  _operationProductEntryRepository.Update(operationProductEntryDto); // Actualizamos el elemento
                operationProductEntryDto = _mapper.Map<OperationProductEntryDto>(operationProductEntry); // Mapear entitidad a dto
                return Ok(operationProductEntryDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var operationProductEntry = _operationProductEntryRepository.Delete(id); // Eliminar elemento
            var operationProductEntryDto = _mapper.Map<OperationProductEntryDto>(operationProductEntry); // Mapear entitidad a dto
            return Ok(operationProductEntryDto);
        }
    }
}
