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
        [HttpGet("Login")]

        public async Task<ActionResult> Login(string nom, string cont)
        {

            var respuestas = _clientesService.Login(nom, cont);
            if (respuestas == null)
            {
                return NotFound();
            }
            else
            {
                APIRespuestas aPIRespuestas = new APIRespuestas();
                aPIRespuestas.Resultado = respuestas;
                return Ok(aPIRespuestas.Resultado);

            }

        }
        #region POSTs...
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> AddCliente(ClienteDTO p_Cliente)
        {
            APIRespuestas respuesta = await _clientesService.CreateAsync(p_Cliente);
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
        #endregion

        [Authorize]

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
