using Api_Agendate_App.DTOs;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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

        [Authorize]
        [HttpGet("BuscarServicioPorIdEmpresa")]
        public async Task<ActionResult> BuscarServicioPorIdEmpresa(int id)
        {
            try
            {
                var respuesta = await _serviciosService.ObtenerServicioPorIdEmpresa(id);
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
        }

        [Authorize]
        [HttpGet("BuscarServicioPorNombreEmpresa")]
        public async Task<ActionResult> BuscarServicioPorNombreEmpresa(string nombreEmpresa)
        {
            try
            {
                var respuesta = await _serviciosService.ObtenerServicioPorNombreEmpresa(nombreEmpresa);
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
        }


        [HttpPost("IngresarServicio")]
        public async Task<ActionResult<ServicioDTO>> AddServicio(ServicioDTO p_Servicio)
        {  
            APIRespuestas respuesta = await _serviciosService.Create(p_Servicio);
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
        [Authorize]
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
        [Authorize]
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
