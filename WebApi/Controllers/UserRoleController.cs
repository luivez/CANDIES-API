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
    [Route("api/usuarioRol/")]
    public class UserRoleController : ControllerBase
    {
        private IUserRoleRepository _userRoleRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public UserRoleController(IUserRoleRepository userRoleRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]UserRoleDto userRoleDto)
        {
            var userRole = _mapper.Map<UserRole>(userRoleDto);  // Mapear dto a entitidad

            try
            {
                userRole = _userRoleRepository.Insert(userRole); // Guardamos el elemento
                userRoleDto = _mapper.Map<UserRoleDto>(userRole);  // Mapear entitidad a dto
                return Ok(userRoleDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var userRoles =  _userRoleRepository.GetAll(); // Listamos elementos
            var userRoleDtos = _mapper.Map<IList<UserRoleDto>>(userRoles); // Mapear entitidad a dto
            return Ok(userRoleDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var userRole =  _userRoleRepository.GetById(id); // Buscamos el elemento
            var userRoleDto = _mapper.Map<UserRoleDto>(userRole); // Mapear entitidad a dto
            return Ok(userRoleDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]UserRoleDto userRoleDto)
        {
            var userRole = _mapper.Map<UserRole>(userRoleDto); // Mapear dto a entitidad

            try
            {
                userRole =  _userRoleRepository.Update(userRoleDto); // Actualizamos el elemento
                userRoleDto = _mapper.Map<UserRoleDto>(userRole); // Mapear entitidad a dto
                return Ok(userRoleDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var userRole = _userRoleRepository.Delete(id); // Eliminar elemento
            var userRoleDto = _mapper.Map<UserRoleDto>(userRole); // Mapear entitidad a dto
            return Ok(userRoleDto);
        }
    }
}
