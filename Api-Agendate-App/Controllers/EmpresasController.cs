using Api_Agendate_App.Models;
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


        public EmpresasController(EmpresasService empresasService, APIRespuestas respuestas)
        {
            _empresasService = empresasService;
            _respuestas = respuestas;
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

        [HttpPost("RegistraseEmpresa")]
        public async Task<ActionResult<EmpresaDTO>> Registrarse(EmpresaDTO usuario)
        {
            APIRespuestas a = new APIRespuestas();
            usuario.Contrasenia = Utilidad.EncriptarClave(usuario.Contrasenia);

            a = await _empresasService.CreateAsync(usuario);
            return Ok(a.Resultado);
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
        public async Task<ActionResult<APIRespuestas>> GetEmpresasMapa()
        {
            try
            {
                var respuesta = await _empresasService.GetEmpresasMapa();
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

        #region POSTs...
        [HttpPost]
        public async Task<ActionResult<EmpresaDTO>> AddEmpresas(EmpresaDTO p_Empresa)
        {
            APIRespuestas respuesta =  await _empresasService.CreateAsync(p_Empresa);
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
        #endregion
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<EmpresaDTO>> Actualizar(EmpresaDTO dTO)
        {
            var respuesta = _empresasService.Update(dTO);
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
        public async Task<ActionResult<APIRespuestas>> Eliminar(string p_NombreUsuario)
        {
            APIRespuestas respuestas = await _empresasService.Delete(p_NombreUsuario);
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
