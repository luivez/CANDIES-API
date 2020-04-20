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
    [Route("api/tipoProducto/")]
    public class ProductTypeController : ControllerBase
    {
        private IProductTypeRepository _productTypeRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public ProductTypeController(IProductTypeRepository productTypeRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]ProductTypeDto productTypeDto)
        {
            var productType = _mapper.Map<ProductType>(productTypeDto);  // Mapear dto a entitidad

            try
            {
                productType = _productTypeRepository.Insert(productType); // Guardamos el elemento
                productTypeDto = _mapper.Map<ProductTypeDto>(productType);  // Mapear entitidad a dto
                return Ok(productTypeDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var productTypes =  _productTypeRepository.GetAll(); // Listamos elementos
            var productTypeDtos = _mapper.Map<IList<ProductTypeDto>>(productTypes); // Mapear entitidad a dto
            return Ok(productTypeDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var productType =  _productTypeRepository.GetById(id); // Buscamos el elemento
            var productTypeDto = _mapper.Map<ProductTypeDto>(productType); // Mapear entitidad a dto
            return Ok(productTypeDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]ProductTypeDto productTypeDto)
        {
            var productType = _mapper.Map<ProductType>(productTypeDto); // Mapear dto a entitidad

            try
            {
                productType =  _productTypeRepository.Update(productTypeDto); // Actualizamos el elemento
                productTypeDto = _mapper.Map<ProductTypeDto>(productType); // Mapear entitidad a dto
                return Ok(productTypeDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var productType = _productTypeRepository.Delete(id); // Eliminar elemento
            var productTypeDto = _mapper.Map<ProductTypeDto>(productType); // Mapear entitidad a dto
            return Ok(productTypeDto);
        }
    }
}
