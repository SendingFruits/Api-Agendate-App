
using Api_Agendate_App.Models;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Repositorio.EntidadesDeRepositorio;

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

        public async Task<ActionResult> LoginUsuario(string usuario, string contra)
        {
            
            UsuarioDTO usuarioU =  _cienteService.Login(usuario,Utilidad.EncriptarClave(contra));
           if (usuarioU == null)
            {
               usuarioU= _empresasService.Login(usuario,  Utilidad.EncriptarClave(contra));
            }


            if (usuarioU != null)
            {
                //Encomtre el usuario
                //Creo un objeto para almacenar al usuario 
                List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, usuarioU.NombreUsuario)
               };
                //Registrando el usuario con una estructura por defecto 
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties authProperties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };
                //Registro como iniciado session al usuario
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties

                    );

                return Ok(usuarioU);
                
            }
          
            else
            {
                return BadRequest("Usuario no encontrado verifique identidades");
            }
           
            
        }
       [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Registrarse(ClienteDTO usuario)
        {
            APIRespuestas a = new APIRespuestas();
            usuario.Contrasenia = Utilidad.EncriptarClave(usuario.Contrasenia);
           
               a  = await _cienteService.CreateAsync(usuario);
               return Ok(a.Resultado);
            
          
          
            


        }
    
        
    }
}
