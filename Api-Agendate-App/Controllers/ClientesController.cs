using Api_Agendate_App.Models;
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

        public ClientesController(ClientesService clientesService)
        {
            _clientesService = clientesService;
        }


        [HttpPost("RegistrarCliente")]
        public async Task<ActionResult<ClienteDTO>> Registrarse(ClienteDTO usuario)
        {
            APIRespuestas respuesta = new APIRespuestas();
            usuario.Contrasenia = Utilidad.EncriptarClave(usuario.Contrasenia);

            try
            {
                respuesta = await _clientesService.CreateAsync(usuario);
                if (respuesta.codigo != 0)
                {
                    return BadRequest(respuesta.mensaje);
                }
                respuesta.Resultado = usuario;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            return Ok(respuesta.mensaje);
        }

        [Authorize]

        [HttpPut("ActualizarCliente")]
        public async Task<ActionResult<ClienteDTO>> UpdateCliente(ClienteDTO _cliente)
        {
            APIRespuestas respuestas = await _clientesService.Update(_cliente);

            if (respuestas.codigo != 0)
            {
                respuestas.ObtenerMensaje(respuestas.codigo);
                return BadRequest(respuestas.mensaje);
                
            }

            return Ok(respuestas.mensaje);
        }

        [HttpDelete]
        public async Task<ActionResult<APIRespuestas>> Eliminar(int id)
        {
            APIRespuestas respuestas = await _clientesService.Delete(id);
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
