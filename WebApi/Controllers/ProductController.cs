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
    [Route("api/producto/")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public ProductController(IProductRepository productRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);  // Mapear dto a entitidad

            try
            {
                product = _productRepository.Insert(product); // Guardamos el elemento
                productDto = _mapper.Map<ProductDto>(product);  // Mapear entitidad a dto
                return Ok(productDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var products =  _productRepository.GetAll(); // Listamos elementos
            var productDtos = _mapper.Map<IList<ProductDto>>(products); // Mapear entitidad a dto
            return Ok(productDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var product =  _productRepository.GetById(id); // Buscamos el elemento
            var productDto = _mapper.Map<ProductDto>(product); // Mapear entitidad a dto
            return Ok(productDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto); // Mapear dto a entitidad

            try
            {
                product =  _productRepository.Update(productDto); // Actualizamos el elemento
                productDto = _mapper.Map<ProductDto>(product); // Mapear entitidad a dto
                return Ok(productDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var product = _productRepository.Delete(id); // Eliminar elemento
            var productDto = _mapper.Map<ProductDto>(product); // Mapear entitidad a dto
            return Ok(productDto);
        }
    }
}
