using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs.Empresas;
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

        [HttpPost("RegistrarEmpresa")]
        public async Task<ActionResult<EmpresaDTO>> Registrarse(EmpresaDTO empresa)
        {
            APIRespuestas respuesta = new APIRespuestas();
            try
            {
                empresa.Contrasenia = Encriptadores.Encriptar(empresa.Contrasenia);
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

        [HttpGet("ObtenerEmpresaPorId")]
        public async Task<ActionResult> GetEmpresas(int id)
        {
            try
            {
                var respuesta = await _empresasService.GetEmpresaPorId(id);
                if (respuesta.Resultado == null)
                {
                    _respuestas.codigo = respuesta.codigo;
                    _respuestas.ObtenerMensaje(_respuestas.codigo);
                    return BadRequest(_respuestas.mensaje);
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
        public async Task<ActionResult<EmpresaDatosBasicosDTO>> Actualizar(EmpresaDatosBasicosDTO dTO)
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

        [HttpDelete]
        public async Task<ActionResult<APIRespuestas>> Eliminar(int id)
        {
            APIRespuestas respuesta = new APIRespuestas();
            try
            {
                APIRespuestas respuestas = await _empresasService.Delete(id);
                if (respuestas.codigo != 0)
                {
                    respuestas.ObtenerMensaje(respuestas.codigo);
                    return BadRequest(respuestas.mensaje);
                }
                
            }
            catch
            {
                return StatusCode(500, ConstantesDeErrores.DevolverMensaje(ConstantesDeErrores.ErrorInesperadoEliminarEmpresa));
            }

            return Ok(respuesta.mensaje);
        }



        [HttpGet("BuscarEnMapa")]
        public async Task<ActionResult> GetEmpresas(string nombre)
        {
            try
            {
                var respuesta = await _empresasService.BuscarEnMapa(nombre);
                if (respuesta.Resultado == null)
                {
                    _respuestas.codigo = respuesta.codigo;
                    _respuestas.ObtenerMensaje(_respuestas.codigo);
                    return BadRequest(_respuestas.mensaje);
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

    }
}
