using Api_Agendate_App.Models;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Logic.Entities;
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

        #region POSTs...
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> AddCliente(ClienteDTO p_Cliente)
        {
            APIRespuestas respuesta =  await _clientesService.CreateAsync(p_Cliente);
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

        [HttpPut ("ActualizarClienete")]
        public async Task<ActionResult<ClienteDTO>> UpdateCliente(ClienteDTO _cliente)
        {
            APIRespuestas respuestas = _clientesService.Update(_cliente);

            if(respuestas.codigo==0)
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


    }


 }
