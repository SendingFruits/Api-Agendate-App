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
            APIRespuestas a = new APIRespuestas();
            usuario.Contrasenia = Utilidad.EncriptarClave(usuario.Contrasenia);

            a = await _clientesService.CreateAsync(usuario);
            return Ok(a.Resultado);


        }

        [Authorize]

        [HttpPut("ActualizarClienete")]
        public async Task<ActionResult<ClienteDTO>> UpdateCliente(ClienteDTO _cliente)
        {
            APIRespuestas respuestas = _clientesService.Update(_cliente);

            if (respuestas.codigo == 0)
            {
                return Ok();
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
            APIRespuestas respuestas = await _clientesService.Delete(p_NombreUsuario);
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
