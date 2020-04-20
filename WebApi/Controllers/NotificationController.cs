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
    [Route("api/notificacion/")]
    public class NotificationController : ControllerBase
    {
        private INotificationRepository _notifRepository; // Agregamos repositorio
        private IMapper _mapper; // Agregamos mapeo de objetos
        private readonly AppSettings _appSettings; // agregamos clave

        // Constructor lleno
        public NotificationController(INotificationRepository notifRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _notifRepository = notifRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("agregar")] // metodo POST para agregar elementos
        public IActionResult Insert([FromBody]NotificationDto notifDto)
        {
            var notif = _mapper.Map<Notification>(notifDto);  // Mapear dto a entitidad

            try
            {
                notif = _notifRepository.Insert(notif); // Guardamos el elemento
                notifDto = _mapper.Map<NotificationDto>(notif);  // Mapear entitidad a dto
                return Ok(notifDto);
            }
            catch(AppException ex) // Si ocurre un error...
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpGet("listar")] // metodo GET para listar elementos
        public IActionResult GetAll()
        {
            var notifs =  _notifRepository.GetAll(); // Listamos elementos
            var notifDtos = _mapper.Map<IList<NotificationDto>>(notifs); // Mapear entitidad a dto
            return Ok(notifDtos);
        }

        [HttpGet("obtener/{id:int}")] // metodo GET para mostrar elemento por id
        public IActionResult GetById(int id)
        {
            var notif =  _notifRepository.GetById(id); // Buscamos el elemento
            var notifDto = _mapper.Map<NotificationDto>(notif); // Mapear entitidad a dto
            return Ok(notifDto);
        }

        [HttpPut("actualizar")] // metodo PUT para actualizar elemento
        public IActionResult Update([FromBody]NotificationDto notifDto)
        {
            var notif = _mapper.Map<Notification>(notifDto); // Mapear dto a entitidad

            try
            {
                notif =  _notifRepository.Update(notifDto); // Actualizamos el elemento
                notifDto = _mapper.Map<NotificationDto>(notif); // Mapear entitidad a dto
                return Ok(notifDto);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message }); // Retornar mensaje de error
            }
        }

        [HttpDelete("eliminar/{id:int}")] // Metodo DELETE para eliminar elemento
        public IActionResult Delete(int id)
        {
            var notif = _notifRepository.Delete(id); // Eliminar elemento
            var notifDto = _mapper.Map<NotificationDto>(notif); // Mapear entitidad a dto
            return Ok(notifDto);
        }
    }
}
