using Api_Agendate_App.Models;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        [HttpPost("RegistrarEmpresa")]
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

        [HttpPut]
        public async Task<ActionResult<EmpresaDTO>> Actualizar (EmpresaDTO dTO)
        {

            APIRespuestas respuestas = _empresasService.Update(dTO);
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

        [HttpDelete]
        public async Task<ActionResult<APIRespuestas>> Eliminar(string p_NombreUsuario)
        {
            APIRespuestas respuestas= await _empresasService.Delete(p_NombreUsuario);
            if(respuestas.codigo==0)
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
