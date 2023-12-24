using Api_Agendate_App.DTOs.Servicio;
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

        
        [HttpGet("BuscarServicioPorIdEmpresa")]
        public async Task<ActionResult<APIRespuestas>> BuscarServicioPorIdEmpresa(int id)
        {
            try
            {
                var respuesta = await _serviciosService.ObtenerServicioPorIdEmpresa(id);
                if (respuesta == null)
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

        
        [HttpGet("BuscarServicioPorNombreEmpresa")]
        public async Task<ActionResult<APIRespuestas>> BuscarServicioPorNombreEmpresa(string nombreEmpresa)
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


        [HttpPost("RegistrarServicio")]
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

        [HttpPut("ActualizarServicio")]
        public async Task<ActionResult<APIRespuestas>> UpdateServicio (ServicioActualizarDTO servicio)
        {
            APIRespuestas respuestas = await _serviciosService.Update(servicio);
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


        [HttpDelete("EliminarServicio")]
        public async Task<ActionResult<APIRespuestas>> Eliminar(int Id)
        {
            APIRespuestas respuestas = await _serviciosService.Delete(Id);
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
