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
    [Route("api/ordenCompra/")]
    public class PurchaseOrderController : ControllerBase
    {
        private IPurchaseOrderRepository _purchaseOrderRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public PurchaseOrderController(IPurchaseOrderRepository purchaseOrderRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]PurchaseOrderDto purchaseOrderDto)
        {
            var purchaseOrder = _mapper.Map<PurchaseOrder>(purchaseOrderDto);  // Mapear dto a entitidad

            try
            {
                purchaseOrder = _purchaseOrderRepository.Insert(purchaseOrder); // Guardamos el elemento
                purchaseOrderDto = _mapper.Map<PurchaseOrderDto>(purchaseOrder);  // Mapear entitidad a dto
                return Ok(purchaseOrderDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var purchaseOrders =  _purchaseOrderRepository.GetAll(); // Listamos elementos
            var purchaseOrderDtos = _mapper.Map<IList<PurchaseOrderDto>>(purchaseOrders); // Mapear entitidad a dto
            return Ok(purchaseOrderDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var purchaseOrder =  _purchaseOrderRepository.GetById(id); // Buscamos el elemento
            var purchaseOrderDto = _mapper.Map<PurchaseOrderDto>(purchaseOrder); // Mapear entitidad a dto
            return Ok(purchaseOrderDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]PurchaseOrderDto purchaseOrderDto)
        {
            var purchaseOrder = _mapper.Map<PurchaseOrder>(purchaseOrderDto); // Mapear dto a entitidad

            try
            {
                purchaseOrder =  _purchaseOrderRepository.Update(purchaseOrderDto); // Actualizamos el elemento
                purchaseOrderDto = _mapper.Map<PurchaseOrderDto>(purchaseOrder); // Mapear entitidad a dto
                return Ok(purchaseOrderDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var purchaseOrder = _purchaseOrderRepository.Delete(id); // Eliminar elemento
            var purchaseOrderDto = _mapper.Map<PurchaseOrderDto>(purchaseOrder); // Mapear entitidad a dto
            return Ok(purchaseOrderDto);
        }
    }
}
