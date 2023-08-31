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

       

        [HttpPost("RegistraseEmpresa")]
        public async Task<ActionResult<EmpresaDTO>> Registrarse(EmpresaDTO usuario)
        {
            APIRespuestas a = new APIRespuestas();
            usuario.Contrasenia = Utilidad.EncriptarClave(usuario.Contrasenia);

            a = await _empresasService.CreateAsync(usuario);
            a.Resultado= usuario;
            return Ok(a.Resultado);


        }

        [HttpGet]
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


        [HttpGet("Obtener Empresas cerca")]
        public async Task<ActionResult<APIRespuestas>> ObtenerEmpresas()
        {
            try
            {
                IEnumerable<EmpresaDTO> ListEmp = (IEnumerable<EmpresaDTO>)_empresasService.ObtenerTodos();
                _respuestas.Resultado = ListEmp;
                _respuestas.codigo = 0;
                return Ok(_respuestas);

            }
            catch (Exception)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorInsertandoEntidad;

            }
            return _respuestas;
        }

        #region POSTs...
       
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
