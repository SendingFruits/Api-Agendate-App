using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs;
using Api_Agendate_App.DTOs.Empresas;

using Api_Agendate_App.DTOs.Promociones;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{

    [ApiController]
    [Route("api/Promociones")]
    public class PromocionesController : ControllerBase
    {
        private readonly APIRespuestas _respuestas;
        private readonly PromocionesService _promoRepoService;
        private readonly MensajeriaService _SNoticar;

        public PromocionesController(PromocionesService promoService, APIRespuestas respuestas, MensajeriaService sNoticar)
        {
            _promoRepoService = promoService;
            _respuestas = respuestas;
            _SNoticar = sNoticar;
        }

        [HttpPut("CrearPromocion")]
        public async Task<ActionResult<APIRespuestas>> CrearPromocion(PromocionDTO PromoN)
        {
            var respuesta = await _promoRepoService.Create(PromoN);
            if (respuesta.codigo != 0)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorInsertandoEntidades;
                _respuestas.ObtenerMensaje(Constantes.ConstantesDeErrores.ErrorInsertandoEntidades);
                return BadRequest(_respuestas.mensaje);
            }
            _respuestas.Resultado = respuesta.Resultado;
            _respuestas.codigo = 0;

            return Ok(_respuestas.Resultado);
        }

        [HttpGet("ObtenerPromocionPorEmpresa")]
        public async Task<ActionResult> GetPromociones(int empresaId)
        {
            try
            {
                var respuesta = await _promoRepoService.GetPromocionesporEmpresa(empresaId);
                if (respuesta == null)
                {
                  
                    _respuestas.ObtenerMensaje(_respuestas.codigo);
                    return BadRequest(_respuestas.mensaje);
                }
                _respuestas.Resultado = respuesta;
                _respuestas.codigo = 0;

                return Ok(_respuestas.Resultado);

            }
            catch (Exception)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorInsertandoEntidad;
                _respuestas.ObtenerMensaje(Constantes.ConstantesDeErrores.ErrorInsertandoEntidad);
                return BadRequest(_respuestas);
            }


        }

        [HttpPut("ActualizarPromocion")]
        public async Task<ActionResult<PromocionDTO>> Actualizar(PromocionDTOActualizar dTO)
        {
            APIRespuestas respuesta = new APIRespuestas();
            try
            {
                respuesta = await _promoRepoService.Modificar(dTO);
                if (respuesta.codigo != 0)
                {
                    respuesta.ObtenerMensaje(respuesta.codigo);
                    return BadRequest(respuesta.mensaje);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, ConstantesDeErrores.DevolverMensaje(ConstantesDeErrores.ErrorInesperadoActualizarEmpresa));
            }

            return Ok(respuesta);
        }

        [HttpDelete("EliminarPromocion")]
        public async Task<ActionResult<APIRespuestas>> Eliminar(int id)
        {
            APIRespuestas respuesta = new APIRespuestas();
            try
            {
                respuesta = await _promoRepoService.Eliminar(id);

                if (respuesta.codigo != 0)
                {
                    return BadRequest(respuesta.mensaje);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ConstantesDeErrores.DevolverMensaje(ConstantesDeErrores.ErrorInesperadoEliminarCliente));
            }

            return Ok(respuesta);
        }

        [HttpPost("EnviarPromocion")]
        public async Task<ActionResult<APIRespuestas>> EnviarPromocion(int idPromocion)
        {
                APIRespuestas respuesta = new APIRespuestas();
            try
            {
                respuesta= await _promoRepoService.EnviarPromocion(idPromocion);
                if (respuesta.codigo != 0)
                {
                    return BadRequest(respuesta.mensaje);
                }

            }
            catch (Exception)
            {

                return StatusCode(500, ConstantesDeErrores.DevolverMensaje(ConstantesDeErrores.ErrorInesperadoEliminarCliente));
            }
            return Ok(respuesta);
        }
    }
}
