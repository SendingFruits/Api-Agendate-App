
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
        private readonly ClientesService _clienteService;
      
        public UsuariosController (EmpresasService empresasService, ClientesService cienteService)
        {
            _empresasService = empresasService;
            _clienteService = cienteService;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> GetUsuarios()
        {
          throw new NotImplementedException();
        }
        

        [HttpGet("Login")]
        public async Task<ActionResult> LoginUsuario(string usuario, string contrasenia)
        {
            if (string.IsNullOrWhiteSpace(usuario) && string.IsNullOrWhiteSpace(contrasenia))
                return BadRequest("El usuario o la contraseña no pueden ser vacíos.");

            UsuarioDTO usuarioU = await _clienteService.Login(usuario,Utilidad.EncriptarClave(contrasenia));
            if (usuarioU == null)
            {
                usuarioU = await _empresasService.Login(usuario,  Utilidad.EncriptarClave(contrasenia));
            } 

            if (usuarioU != null)
            {
                return Ok(usuarioU);
            }
          
            return BadRequest("Usuario no encontrado verifique identidades");
        }
    }
}
