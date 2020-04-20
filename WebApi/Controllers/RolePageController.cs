using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using WebApi.Entities;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/rolpagina/")]
    public class RolePageController : ControllerBase
    {
        private IRolePageRepository _rolePageRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public RolePageController(IRolePageRepository rolePageRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _rolePageRepository = rolePageRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]RolePageDto rolePageDto)
        {
            var rolePage = _mapper.Map<RolePage>(rolePageDto);  // Mapear dto a entitidad

            try
            {
                rolePage = _rolePageRepository.Insert(rolePage); // Guardamos el elemento
                rolePageDto = _mapper.Map<RolePageDto>(rolePage);  // Mapear entitidad a dto
                return Ok(rolePageDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var rolePages =  _rolePageRepository.GetAll(); // Listamos elementos
            var rolePageDtos = _mapper.Map<IList<RolePageDto>>(rolePages); // Mapear entitidad a dto
            return Ok(rolePageDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var rolePage =  _rolePageRepository.GetById(id); // Buscamos el elemento
            var rolePageDto = _mapper.Map<RolePageDto>(rolePage); // Mapear entitidad a dto
            return Ok(rolePageDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]RolePageDto rolePageDto)
        {
            var rolePage = _mapper.Map<RolePage>(rolePageDto); // Mapear dto a entitidad

            try
            {
                rolePage =  _rolePageRepository.Update(rolePageDto); // Actualizamos el elemento
                rolePageDto = _mapper.Map<RolePageDto>(rolePage); // Mapear entitidad a dto
                return Ok(rolePageDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var rolePage = _rolePageRepository.Delete(id); // Eliminar elemento
            var rolePageDto = _mapper.Map<RolePageDto>(rolePage); // Mapear entitidad a dto
            return Ok(rolePageDto);
        }
    }
}
