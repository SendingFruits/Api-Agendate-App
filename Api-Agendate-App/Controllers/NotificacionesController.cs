using Api_Agendate_App.Models;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{

    [ApiController]
    [Route("api/Notificaciones")]
    public class NotificacionesController : Controller
    {
        private readonly APIRespuestas _respuestas;
        private readonly NotificacionesService _Noti;

        public NotificacionesController(APIRespuestas respuestas, NotificacionesService noti)
        {
            _respuestas = respuestas;
            _Noti = noti;
        }

        [HttpPost]
        public async Task<ActionResult<APIRespuestas>> Crear(NotificacionDTO Noti)
        {
            try
            {
                var respuesta = await _Noti.CreateMail(Noti);

                return Ok(respuesta);


            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

    }
}