using Api_Agendate_App.Models;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{
    [ApiController]
    [Route("api/Servicios")]
    public class ServiciosController: ControllerBase
    {

        private readonly APIRespuestas _respuestas;
        private readonly ServiciosService _serviciosService;

        public ServiciosController(APIRespuestas aPIRespuestas, ServiciosService serviciosService)
        {
            _respuestas= aPIRespuestas;
            _serviciosService= serviciosService;
        }


        [HttpGet]
        public async Task<ActionResult> GetServicios()
        {
            try
            {
                var respuesta = await _serviciosService.GetSErvicios();
                if (respuesta == null)
                {
                    _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorEntidadesInexistentes;
                    _respuestas.ObtenerMensaje(Constantes.ConstantesDeErrores.ErrorEntidadesInexistentes);
                }
                _respuestas.Resultado = respuesta.ToList();
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
        [HttpGet("Buscar Servicio por empresa")]
        public async Task<ActionResult>GetServicioporEmpresa(string NomEmp)
        {
            try
            {
                var respuesta = await _serviciosService.ObtenerServEmp(NomEmp);
                if (respuesta == null)
                {
                    _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorEntidadesInexistentes;
                    _respuestas.ObtenerMensaje(Constantes.ConstantesDeErrores.ErrorEntidadesInexistentes);
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
            /* try
             {
                 var respuesta = await _serviciosService.ObtenerServEmp(idEmp);
                 if (respuesta == null)
                 {
                     _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorEntidadesInexistentes;
                     _respuestas.ObtenerMensaje(Constantes.ConstantesDeErrores.ErrorEntidadesInexistentes);
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
             }*/
        }

        [HttpPost]
        public async Task<ActionResult<ServicioDTO>> AddServicio(ServicioDTO p_Servicio)
        {  
            // Ver aca porque al crear un servicio tengo que comprobar que el que esta dando de alta el servicio sea una empresa 
            //y que cree el servicio para sí misma , de lo contrario no podría dar de alta .

            APIRespuestas respuesta = _serviciosService.Create(p_Servicio);
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
        [HttpPut]
            public async Task<ActionResult<APIRespuestas>> Actualizar(ServicioDTO dTO)
            {

                APIRespuestas respuestas = _serviciosService.Update(dTO);
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
        public async Task<ActionResult<APIRespuestas>> Eliminar(int Id)
        {

            
            APIRespuestas respuestas = _serviciosService.Delete(Id);
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
