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
        [HttpGet("Login")]

        public async Task<ActionResult<APIRespuestas>> Login(string nom, string cont)
        {

            var respuesta = _empresasService.Login(nom, cont);
            if (respuesta == null)
            { 
                return NotFound();
            }
            else
            {
                _respuestas.Resultado= respuesta;
               
                return Ok(_respuestas.Resultado);

            }

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
