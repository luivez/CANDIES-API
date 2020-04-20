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
    [Route("api/proveedor/")]
    public class ProviderController : ControllerBase
    {
        private IProviderRepository _providerRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public ProviderController(IProviderRepository providerRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]ProviderDto providerDto)
        {
            var provider = _mapper.Map<Provider>(providerDto);  // Mapear dto a entitidad

            try
            {
                provider = _providerRepository.Insert(provider); // Guardamos el elemento
                providerDto = _mapper.Map<ProviderDto>(provider);  // Mapear entitidad a dto
                return Ok(providerDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var providers =  _providerRepository.GetAll(); // Listamos elementos
            var providerDtos = _mapper.Map<IList<ProviderDto>>(providers); // Mapear entitidad a dto
            return Ok(providerDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var provider =  _providerRepository.GetById(id); // Buscamos el elemento
            var providerDto = _mapper.Map<ProviderDto>(provider); // Mapear entitidad a dto
            return Ok(providerDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]ProviderDto providerDto)
        {
            var provider = _mapper.Map<Provider>(providerDto); // Mapear dto a entitidad

            try
            {
                provider =  _providerRepository.Update(providerDto); // Actualizamos el elemento
                providerDto = _mapper.Map<ProviderDto>(provider); // Mapear entitidad a dto
                return Ok(providerDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var provider = _providerRepository.Delete(id); // Eliminar elemento
            var providerDto = _mapper.Map<ProviderDto>(provider); // Mapear entitidad a dto
            return Ok(providerDto);
        }
    }
}
