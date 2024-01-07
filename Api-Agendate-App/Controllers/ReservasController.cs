using Api_Agendate_App.DTOs.Reservas;
using Api_Agendate_App.DTOs.Servicio;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{
    [ApiController]
    [Route("api/Reservas")]
    public class ReservasController : ControllerBase
    {

        private readonly APIRespuestas _respuestas;
        private readonly ReservasService _ReservasService;

        public ReservasController(APIRespuestas aPIRespuestas, ReservasService reservasService)
        {
            _respuestas = aPIRespuestas;
            _ReservasService = reservasService;
        }

        [HttpPost("RegistrarReserva")]
        public async Task<ActionResult<ServicioDTO>> AddReserva(ReservaDTO pReserva)
        {
            APIRespuestas respuesta = await _ReservasService.Create(pReserva);
            if (respuesta.codigo == 0)
            {
                return Ok();
            }
            else
            {
                respuesta.ObtenerMensaje(respuesta.codigo);
                return BadRequest(respuesta.mensaje);
            }

        }

        [HttpPut("ActualizarReserva")]
        public async Task<ActionResult<APIRespuestas>> UpdateReserva(ReservaDTO pReserva)
        {
            APIRespuestas respuestas = await _ReservasService.Update(pReserva);
            if (respuestas.codigo == 0)
            {
                return Ok(respuestas);
            }
            else
            {
                respuestas.ObtenerMensaje(respuestas.codigo);
                return BadRequest(respuestas.mensaje);
            }

        }


        [HttpDelete("EliminarReserva")]
        public async Task<ActionResult<APIRespuestas>> Eliminar(int Id)
        {
            APIRespuestas respuestas = await _ReservasService.Delete(Id);
            if (respuestas.codigo == 0)
            {
                return Ok(respuestas);

            }
            else
            {
                respuestas.ObtenerMensaje(respuestas.codigo);
                return BadRequest(respuestas.mensaje);
            }
        }

        [HttpGet("ObtenerHorariosSegunFecha")]
        public async Task<ActionResult<APIRespuestas>> ObtenerHorariosSegunFecha(int idServicio, DateTime fecha)
        {
            APIRespuestas respuesta = await _ReservasService.ObtenerHorariosSegunFecha(idServicio, fecha);

            if (respuesta.codigo == 0)
            {
                return Ok(respuesta);
            }
            else
                return BadRequest(respuesta.mensaje);

        }
    }
}
