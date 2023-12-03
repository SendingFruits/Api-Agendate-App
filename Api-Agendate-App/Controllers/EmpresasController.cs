using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs;
using Api_Agendate_App.Seguridad;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{

    [ApiController]
    [Route("api/Empresas")]
    public class EmpresasController : ControllerBase
    {
        private readonly APIRespuestas _respuestas;
        private readonly EmpresasService _empresasService;
        private readonly MensajeriaService _SNoticar;

        public EmpresasController(EmpresasService empresasService, APIRespuestas respuestas, MensajeriaService sNoticar)
        {
            _empresasService = empresasService;
            _respuestas = respuestas;
            _SNoticar = sNoticar;
        }

        

        [HttpGet("BuscarEmpresaxNombre")]
        public async Task<ActionResult> BuscarEmpresaNombre(string nom)
        {
            try
            {
                var respuesta = await _empresasService.GetEmpresas(nom);
                if (respuesta.Resultado == null)
                {
                    _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorEntidadesInexistentes;
                    _respuestas.ObtenerMensaje(Constantes.ConstantesDeErrores.ErrorEntidadesInexistentes);
                }
                _respuestas.Resultado = respuesta.Resultado;
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


        [HttpGet("ObtenerEmpresasMapa")]
        public async Task<ActionResult<APIRespuestas>> GetEmpresasMapa(float radioCircunferencia, float latitudeCliente, float longitudeCliente)
        {
            try
            {
                var respuesta = await _empresasService.GetEmpresasMapa(radioCircunferencia, latitudeCliente, longitudeCliente);
                _respuestas.Resultado = respuesta.Resultado;
                _respuestas.codigo = respuesta.codigo;
                return Ok(_respuestas.Resultado);
            }
            catch (Exception)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorInsertandoEntidad;
            }
            return Ok(_respuestas.Resultado);
        }

        
        //[Authorize]
        [HttpPut("ActualizarEmpresa")]
        public async Task<ActionResult<EmpresaDTO>> Actualizar(EmpresaDTO dTO)
        {
            APIRespuestas respuesta = new APIRespuestas();
            try
            {
                respuesta = await _empresasService.UpdateAsync(dTO);
                if (respuesta.codigo != 0)
                {
                    respuesta.ObtenerMensaje(respuesta.codigo);
                    return BadRequest(respuesta.mensaje);
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ConstantesDeErrores.DevolverMensaje(ConstantesDeErrores.ErrorInesperadoActualizarEmpresa));
            }

            return Ok(respuesta);
        }

     

    }
}
