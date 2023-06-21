
using Api_Agendate_App.Models;
using Api_Agendate_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Agendate_App.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuariosController : ControllerBase
    {
        
        private readonly EmpresasService _empresasService;
        private readonly ClientesService _cienteService;


        public UsuariosController (EmpresasService empresasService, ClientesService cienteService)
        {
            _empresasService = empresasService;
            _cienteService = cienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> GetUsuarios()
        {
            List<UsuarioDTO> list= new List<UsuarioDTO>();
            return list.ToList();
            //
        }
        

        [HttpGet("Login")]

        public async Task<ActionResult<List<UsuarioDTO>>> LoginUsuario(string usuario, string contrasenia)
        {
            var usuarioU = _cienteService.Login(usuario, contrasenia);
           


            if(usuarioU != null)
            { 
                return Ok(usuario);
                
            }
          
            else
            {
                return BadRequest("Usuario no encontrado verifique identidades");
            }
           
            
        }

      /*  [HttpPost]
        public async Task<ActionResult<List<UsuarioDTO>>> AddUsuarioEmpresa(EmpresaDTO usu)
        {
            //Verificar si existe el usuario con el documento identificatorio
            //Si no existe, lo agrego

        }
       
        */
        
    }
}
