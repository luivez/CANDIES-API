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
    [Authorize]
    [ApiController]
    [Route("api/rol/")]
    public class RoleController : ControllerBase
    {
        private IRoleRepository _roleRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public RoleController(IRoleRepository roleRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);  // Mapear dto a entitidad

            try
            {
                role = _roleRepository.Insert(role); // Guardamos el elemento
                roleDto = _mapper.Map<RoleDto>(role);  // Mapear entitidad a dto
                return Ok(roleDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var roles =  _roleRepository.GetAll(); // Listamos elementos
            var roleDtos = _mapper.Map<IList<RoleDto>>(roles); // Mapear entitidad a dto
            return Ok(roleDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var role =  _roleRepository.GetById(id); // Buscamos el elemento
            var roleDto = _mapper.Map<RoleDto>(role); // Mapear entitidad a dto
            return Ok(roleDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto); // Mapear dto a entitidad

            try
            {
                role =  _roleRepository.Update(roleDto); // Actualizamos el elemento
                roleDto = _mapper.Map<RoleDto>(role); // Mapear entitidad a dto
                return Ok(roleDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var role = _roleRepository.Delete(id); // Eliminar elemento
            var roleDto = _mapper.Map<RoleDto>(role); // Mapear entitidad a dto
            return Ok(roleDto);
        }
    }
}
