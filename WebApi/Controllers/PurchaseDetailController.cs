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
    [Route("api/detalleCompra/")]
    public class PurchaseDetailController : ControllerBase
    {
        private IPurchaseDetailRepository _purchaseDetailRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public PurchaseDetailController(IPurchaseDetailRepository purchaseDetailRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _purchaseDetailRepository = purchaseDetailRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]PurchaseDetailDto purchaseDetailDto)
        {
            var purchaseDetail = _mapper.Map<PurchaseDetail>(purchaseDetailDto);  // Mapear dto a entitidad

            try
            {
                purchaseDetail = _purchaseDetailRepository.Insert(purchaseDetail); // Guardamos el elemento
                purchaseDetailDto = _mapper.Map<PurchaseDetailDto>(purchaseDetail);  // Mapear entitidad a dto
                return Ok(purchaseDetailDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var purchaseDetails =  _purchaseDetailRepository.GetAll(); // Listamos elementos
            var purchaseDetailDtos = _mapper.Map<IList<PurchaseDetailDto>>(purchaseDetails); // Mapear entitidad a dto
            return Ok(purchaseDetailDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var purchaseDetail =  _purchaseDetailRepository.GetById(id); // Buscamos el elemento
            var purchaseDetailDto = _mapper.Map<PurchaseDetailDto>(purchaseDetail); // Mapear entitidad a dto
            return Ok(purchaseDetailDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]PurchaseDetailDto purchaseDetailDto)
        {
            var purchaseDetail = _mapper.Map<PurchaseDetail>(purchaseDetailDto); // Mapear dto a entitidad

            try
            {
                purchaseDetail =  _purchaseDetailRepository.Update(purchaseDetailDto); // Actualizamos el elemento
                purchaseDetailDto = _mapper.Map<PurchaseDetailDto>(purchaseDetail); // Mapear entitidad a dto
                return Ok(purchaseDetailDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var purchaseDetail = _purchaseDetailRepository.Delete(id); // Eliminar elemento
            var purchaseDetailDto = _mapper.Map<PurchaseDetailDto>(purchaseDetail); // Mapear entitidad a dto
            return Ok(purchaseDetailDto);
        }
    }
}
