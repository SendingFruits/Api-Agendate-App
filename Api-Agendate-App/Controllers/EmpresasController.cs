using Api_Agendate_App.Models;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Logic.Entities;
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
        [HttpGet]
        public async Task<ActionResult<APIRespuestas>> GetEmpresas()
        {
            try
            {
                IEnumerable<EmpresaDTO> ListEmp = (IEnumerable<EmpresaDTO>)_empresasService.GetEmpresas();
                _respuestas.Resultado = ListEmp;
                _respuestas.codigo = Constantes.ConstantesDeErrores.Exito;
                return Ok(_respuestas);

            }
            catch (Exception)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorInsertandoEntidad;

            }
            return _respuestas;
        }


        [HttpGet ("Obtener Empresas cerca")]
        public async Task<ActionResult<APIRespuestas>> ObtenerEmpresas(decimal longitud, decimal latitud)
        {
            try
            {
                IEnumerable<EmpresaDTO> ListEmp = (IEnumerable<EmpresaDTO>)_empresasService.ObtenerTodos(longitud,latitud);
                _respuestas.Resultado = ListEmp;
                _respuestas.codigo = Constantes.ConstantesDeErrores.Exito;
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
            APIRespuestas respuesta =  _empresasService.Create(p_Empresa);
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




        [HttpPut ]
        public async Task<ActionResult<APIRespuestas>> Actualizar (EmpresaDTO dTO)
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
        public async Task<ActionResult<APIRespuestas>> Eliminar(EmpresaDTO dTO)
        {
            APIRespuestas respuestas= _empresasService.Delete(dTO);
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
