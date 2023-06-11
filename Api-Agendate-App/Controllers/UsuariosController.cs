using Api_Agendate_App.Services;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuariosController : ControllerBase
    {

        private readonly UsuariosService _usuariosService;

        public UsuariosController (UsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }
         
        //[HttpGet]
        //public async Task<ActionResult<List<UsuarioDTO>>> GetUsuarios(UsuarioDTO usuario)
        //{
        //    UsuarioDTO usuario = new UsuarioDTO();


        //    return Ok(usuario);
        //}

        [HttpPost]
        public  IActionResult AddCliente(Cliente p_Cliente)
        {

            var nuevoCliente = _usuariosService.Create(p_Cliente);

            return Ok(nuevoCliente);
        }
    }
}
