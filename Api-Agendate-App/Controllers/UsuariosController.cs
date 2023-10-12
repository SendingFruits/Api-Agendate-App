
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
        private readonly UsuariosService _usuariosService;
        public UsuariosController (EmpresasService empresasService, ClientesService clienteService, UsuariosService usuariosService)
        {
            _empresasService = empresasService;
            _clienteService = clienteService;
            _usuariosService = usuariosService;

        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginUsuario(string pUsuario, string pContrasenia)
        {
            APIRespuestas resp = new APIRespuestas();
            UsuarioDTO usuario = null;
            try
            {
                if (string.IsNullOrWhiteSpace(pUsuario) && string.IsNullOrWhiteSpace(pContrasenia))
                {
                    return BadRequest("Las credenciales de ingreso están vacías");
                }

                usuario = await _clienteService.Login(pUsuario, Encriptadores.Encriptar(pContrasenia));
                if (usuario == null)
                {
                    usuario = await _empresasService.Login(pUsuario, Encriptadores.Encriptar(pContrasenia));
                }

                if (usuario == null)
                {
                    return BadRequest("Usuario no encontrado verifique identidades");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(usuario);
        }

        [HttpPut("ActualizarContrasenia")]
        public async Task<ActionResult> ActualizarContrasenia(int idUsuario, string passVieja, string passNueva)
        {
            APIRespuestas respuesta = new APIRespuestas();

            try
            {
                if (string.IsNullOrWhiteSpace(passVieja))
                {
                    respuesta.codigo = ConstantesDeErrores.ErrorClaveViejaIngresadaConfirmarVacia;
                    respuesta.mensaje = ConstantesDeErrores.DevolverMensaje(respuesta.codigo);
                    return BadRequest(respuesta.mensaje);
                }

                if (string.IsNullOrWhiteSpace(passNueva))
                {
                    respuesta.codigo = ConstantesDeErrores.ErrorClaveNuevaIngresadaConfirmarVacia;
                    respuesta.mensaje = ConstantesDeErrores.DevolverMensaje(respuesta.codigo);
                    return BadRequest(respuesta.mensaje);
                }

                if (idUsuario == 0 || idUsuario == null)
                {
                    respuesta.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    respuesta.mensaje = ConstantesDeErrores.DevolverMensaje(respuesta.codigo);
                    return BadRequest(respuesta.mensaje);
                }

                respuesta = await _usuariosService.ModificarContrasenia(idUsuario, passVieja, passNueva);

                if (respuesta.codigo != 0) return BadRequest(respuesta.mensaje);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ConstantesDeErrores.DevolverMensaje(ConstantesDeErrores.ErrorInesperadoActualizarContrasenia));
            }
            
            return Ok(respuesta.mensaje);
        }
    }
}
