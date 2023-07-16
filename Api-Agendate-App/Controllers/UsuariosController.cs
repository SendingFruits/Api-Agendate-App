
using Api_Agendate_App.Models;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Logic.Entities;
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
          throw new NotImplementedException();
        }
        

        [HttpGet("Login")]

        public async Task<ActionResult<List<UsuarioDTO>>> LoginUsuario(string usuario, string contrasenia)
        {
           UsuarioDTO usuarioU = _cienteService.Login(usuario, contrasenia);
           if (usuarioU == null)
            {
               usuarioU= _empresasService.Login(usuario, contrasenia);
            }


            if(usuarioU != null)
            { 
                return Ok(usuarioU);
                
            }
          
            else
            {
                return BadRequest("Usuario no encontrado verifique identidades");
            }
           
            
        }

    
        
    }
}
