using Api_Agendate_App.DTOs;
using Api_Agendate_App.Models;
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

        [HttpPost("Loging")]
        public async Task<ActionResult<APIRespuestas>> Login(string nom, string cont)
        {

            var respuesta = await _empresasService.Login(nom, cont);
            if (respuesta == null)
            {
                return NotFound();
            }
            else
            {
                _respuestas.Resultado = respuesta;

                return Ok(_respuestas.Resultado);

            }

        }

        [HttpPost("RegistrarEmpresa")]
        public async Task<ActionResult<EmpresaDTO>> Registrarse(EmpresaDTO empresa)

        {
            APIRespuestas respuesta = new APIRespuestas();
            empresa.Contrasenia = Encriptadores.Encriptar(empresa.Contrasenia);

            try
            {
                respuesta = await _empresasService.CreateAsync(empresa);
                if (respuesta.codigo != 0)
                {
                    return BadRequest(respuesta.mensaje);
                }
                respuesta.Resultado = respuesta.Resultado;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(respuesta.mensaje);

        }

        [HttpGet("ObtenerEmpresas")]
        public async Task<ActionResult> GetEmpresas()
        {
            try
            {
                var respuesta = await _empresasService.GetEmpresas();
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
        [HttpPut]
        public async Task<ActionResult<EmpresaDTO>> Actualizar(EmpresaDTO dTO)
        {
            APIRespuestas  respuesta = await _empresasService.UpdateAsync(dTO);
            if (respuesta.codigo == 0)
            {
                return Ok(respuesta);
            }
            else
            {
                respuesta.ObtenerMensaje(respuesta.codigo);
                return BadRequest(respuesta.mensaje);
            }


        }

        [HttpDelete]
        public async Task<ActionResult<APIRespuestas>> Eliminar(int id)
        {
            APIRespuestas respuestas = await _empresasService.Delete(id);
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

    }
}
