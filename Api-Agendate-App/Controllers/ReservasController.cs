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

        [HttpPut("CancelarReserva")]
        public async Task<ActionResult<APIRespuestas>> CancelarReserva(int idReserva)
        {
            try
            {
                APIRespuestas respuestas = await _ReservasService.CancelarReserva(idReserva);
                if (respuestas.codigo == 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(respuestas.mensaje);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CambiarEstadoReserva")]
        public async Task<ActionResult<APIRespuestas>> CambiarEstadoReserva(int idReserva, string estadoNuevo)
        {
            APIRespuestas respuestas = await _ReservasService.CambiarEstadoReserva(idReserva, estadoNuevo);
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
        public async Task<ActionResult> ObtenerHorariosSegunFecha(int idServicio, DateTime fecha)
        {
            try
            {
                APIRespuestas respuesta = await _ReservasService.ObtenerHorariosSegunFecha(idServicio, fecha);
                _respuestas.Resultado = respuesta.Resultado;
                _respuestas.codigo = respuesta.codigo;
                if (respuesta.codigo != 0)
                {
                    return BadRequest(_respuestas);
                }
            }
            catch (Exception)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorInsertandoEntidad;
            }
            return Ok(_respuestas);

        }

        [HttpGet("ObtenerReservasDeEmpresas")]
        public async Task<ActionResult> ObtenerReservasDeEmpresas(int idServicio, DateTime fecha)
        {
            try
            {
                APIRespuestas respuesta = await _ReservasService.ObtenerReservasSegunFechaParaEmpresas(idServicio, fecha);
                _respuestas.Resultado = respuesta.Resultado;
                _respuestas.codigo = respuesta.codigo;
                if (respuesta.codigo != 0)
                {
                    return BadRequest(_respuestas);
                }
            }
            catch (Exception)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorInsertandoEntidad;
            }
            return Ok(_respuestas.Resultado);

        }

        [HttpGet("ObtenerReservasDeClientes")]
        public async Task<ActionResult> ObtenerReservasDeClientes(int idCliente)
        {
            try
            {
                APIRespuestas respuesta = await _ReservasService.ObtenerReservasParaClientes(idCliente);
                _respuestas.Resultado = respuesta.Resultado;
                _respuestas.codigo = respuesta.codigo;
                if (respuesta.codigo != 0)
                {
                    return BadRequest(_respuestas);
                }
            }
            catch (Exception)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorInsertandoEntidad;
            }
            return Ok(_respuestas.Resultado);

        }
    }
}
