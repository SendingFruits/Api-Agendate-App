
using Api_Agendate_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuariosController : ControllerBase
    {
         private static List<UsuarioDTO> usuarios = new List<UsuarioDTO>
            {
                new UsuarioDTO {
                    id = 1,
                    usuario = "Miusuario",
                    contraseña = "Unacontrasenia",
                    nombreCompleto = "Leeroy Jenkinsss",
                    correoElectronico = "casilla@gmail.com.uy"


                }
            };

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> GetUsuarios()
        {
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<List<UsuarioDTO>>> AddUsuario(UsuarioDTO usu)
        {
            usuarios.Add(usu);
            return Ok(usuarios);
        }
    }
}
