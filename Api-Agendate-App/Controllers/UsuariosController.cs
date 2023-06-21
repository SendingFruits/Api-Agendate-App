
using Api_Agendate_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Agendate_App.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuariosController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> GetUsuarios()
        {
            //
        }

        [HttpPost]
        public async Task<ActionResult<List<UsuarioDTO>>> AddUsuarioEmpresa(EmpresaDTO usu)
        {
            //Verificar si existe el usuario con el documento identificatorio
            //Si no existe, lo agrego

        }
    }
}
