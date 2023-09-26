
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
using Api_Agendate_App.Constantes;
using Api_Agendate_App.Seguridad;

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

        [HttpPost("Login")]
        public async Task<ActionResult> LoginUsuario(string pUsuario, string pContrasenia)
        {
            APIRespuestas resp = new APIRespuestas();

            if (string.IsNullOrWhiteSpace(pUsuario) && string.IsNullOrWhiteSpace(pContrasenia))
            {
                return BadRequest("Las credenciales de ingreso no pueden ser vacías");
            }
                
            UsuarioDTO usuario = await _clienteService.Login(pUsuario, Encriptadores.Encriptar(pContrasenia));
            if (usuario == null)
            {
                usuario = await _empresasService.Login(pUsuario, Encriptadores.Encriptar(pContrasenia));
            } 

            if (usuario == null)
            {
                return BadRequest("Usuario no encontrado verifique identidades");
            }

            return Ok(usuario);
        }

        [HttpPut("Login")]
        public async Task<ActionResult> ActualizarContrasenia(int idUsuario, string passVieja, string passNueva)
        {
            APIRespuestas respuesta = new APIRespuestas();

            if (string.IsNullOrWhiteSpace(passVieja) || string.IsNullOrWhiteSpace(passNueva))
            {
                return BadRequest("Las credenciales de ingreso no pueden ser vacías");
            }

            UsuarioDTO usuario = await _clienteService.Login(pUsuario, Encriptadores.Encriptar(pContrasenia));
            if (usuario == null)
            {
                usuario = await _empresasService.Login(pUsuario, Encriptadores.Encriptar(pContrasenia));
            }

            if (usuario == null)
            {
                return BadRequest("Usuario no encontrado verifique identidades");
            }

            return Ok(usuario);
        }
    }
}
