
using Api_Agendate_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{
    [ApiController]
    [Route("api/obtenerUsuarios")]
    public class UsuariosController : ControllerBase
    {
         private static List<MUsuarios> usuarios = new List<MUsuarios>
            {
                new MUsuarios {
                    id = 1,
                    usuario = "Miusuario",
                    contraseña = "Unacontrasenia",
                    nombreCompleto = "Leeroy Jenkinsss",
                    correoElectronico = "casilla@gmail.com.uy"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<MUsuarios>>> GetUsuarios()
        {
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<List<MUsuarios>>> AddUsuario(MUsuarios usu)
        {
            usuarios.Add(usu);
            return Ok(usuarios);
        }
    }
}
