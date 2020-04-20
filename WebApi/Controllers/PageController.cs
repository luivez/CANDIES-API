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
    [Route("api/pagina/")]
    public class PageController : ControllerBase
    {
        private IPageRepository _pageRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public PageController(IPageRepository pageRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _pageRepository = pageRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]PageDto pageDto)
        {
            var page = _mapper.Map<Page>(pageDto);  // Mapear dto a entitidad

            try
            {
                page = _pageRepository.Insert(page); // Guardamos el elemento
                pageDto = _mapper.Map<PageDto>(page);  // Mapear entitidad a dto
                return Ok(pageDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var pages =  _pageRepository.GetAll(); // Listamos elementos
            var pageDtos = _mapper.Map<IList<PageDto>>(pages); // Mapear entitidad a dto
            return Ok(pageDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var page =  _pageRepository.GetById(id); // Buscamos el elemento
            var pageDto = _mapper.Map<PageDto>(page); // Mapear entitidad a dto
            return Ok(pageDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]PageDto pageDto)
        {
            var page = _mapper.Map<Page>(pageDto); // Mapear dto a entitidad

            try
            {
                page =  _pageRepository.Update(pageDto); // Actualizamos el elemento
                pageDto = _mapper.Map<PageDto>(page); // Mapear entitidad a dto
                return Ok(pageDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var page = _pageRepository.Delete(id); // Eliminar elemento
            var pageDto = _mapper.Map<PageDto>(page); // Mapear entitidad a dto
            return Ok(pageDto);
        }
    }
}
