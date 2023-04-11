
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
                    usuario = "usuario",
                    contraseña = "contrasenia",
                    nombreCompleto = "Estebaqweqwen",
                    correoElectronico = "estebwqeqweqwean@gmail.com.uy"
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
