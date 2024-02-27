using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs;
using Api_Agendate_App.Seguridad;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Logic.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{
    [ApiController]
    [Route("api/Clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _clientesService;
        private readonly APIRespuestas _respuestas;

        public ClientesController(ClientesService clientesService, APIRespuestas respuestas)
        {
            _clientesService = clientesService;
            _respuestas = respuestas;
        }

        [HttpPost("RegistrarCliente")]
        public async Task<ActionResult<ClienteDTO>> Registrarse(ClienteDTO usuario)
        {
            APIRespuestas respuesta = new APIRespuestas();
            try
            {
                usuario.Contrasenia = Encriptadores.Encriptar(usuario.Contrasenia);
                respuesta = await _clientesService.CreateAsync(usuario);
                if (respuesta.codigo != 0)
                {
                    return BadRequest(respuesta.mensaje);
                }
                respuesta.Resultado = usuario;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ConstantesDeErrores.DevolverMensaje(ConstantesDeErrores.ErrorInesperadoRegistrarCliente));
            }
            
            return Ok(respuesta.mensaje);
        }

        [HttpPut("ModificarNotificaciones")]
        public async Task<ActionResult<APIRespuestas>> ModificarNotificacionesFavoritos(int idCliente, bool quiereNotificacion)
        {
            var respuesta = await _clientesService.ModificarNotificaciones(idCliente, quiereNotificacion);
            if (respuesta.codigo != 0)
            {
                _respuestas.codigo = Constantes.ConstantesDeErrores.ErrorInsertandoEntidades;
                _respuestas.ObtenerMensaje(Constantes.ConstantesDeErrores.ErrorInsertandoEntidades);
                return BadRequest(_respuestas.mensaje);
            }

            _respuestas.Resultado = respuesta.Resultado;

            return Ok(_respuestas.Resultado);
        }
    }
 }