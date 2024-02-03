using Api_Agendate_App.DTOs;
using Api_Agendate_App.Services;
using Api_Agendate_App.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Api_Agendate_App.Constantes;
using Api_Agendate_App.Seguridad;
using Api_Agendate_App.DTOs.Usuarios;

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

        [HttpPut("ActualizarDatosBasicosUsuarios")]
        public async Task<ActionResult> ActualizarDatosBasicos(UsuarioDatosBasicosDTO usuario)
        {
            APIRespuestas respuesta = new APIRespuestas();

            try
            {
                respuesta = await _usuariosService.ActualizarDatosBasicosUsuario(usuario);

                if (respuesta.codigo != 0)
                {
                    respuesta.ObtenerMensaje(respuesta.codigo);
                    return BadRequest(respuesta.mensaje);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ConstantesDeErrores.DevolverMensaje(ConstantesDeErrores.ErrorInesperadoActualizarCliente));
            }

            return Ok(respuesta.mensaje);
            
        }

        [HttpPut("ActualizarContraseniaBody")]
        public async Task<ActionResult> ActualizarContraseniaBody([FromBody] UsuarioPassDTO userPass)
        {
            APIRespuestas respuesta = new APIRespuestas();

            try
            {
                if (string.IsNullOrWhiteSpace(userPass.PassVieja))
                {
                    respuesta.codigo = ConstantesDeErrores.ErrorClaveViejaIngresadaConfirmarVacia;
                    respuesta.mensaje = ConstantesDeErrores.DevolverMensaje(respuesta.codigo);
                    return BadRequest(respuesta.mensaje);
                }

                if (string.IsNullOrWhiteSpace(userPass.PassNueva))
                {
                    respuesta.codigo = ConstantesDeErrores.ErrorClaveNuevaIngresadaConfirmarVacia;
                    respuesta.mensaje = ConstantesDeErrores.DevolverMensaje(respuesta.codigo);
                    return BadRequest(respuesta.mensaje);
                }

                if (userPass.Id == 0)
                {
                    respuesta.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    respuesta.mensaje = ConstantesDeErrores.DevolverMensaje(respuesta.codigo);
                    return BadRequest(respuesta.mensaje);
                }

                respuesta = await _usuariosService.ModificarContrasenia(userPass.Id, userPass.PassVieja, userPass.PassNueva);

                if (respuesta.codigo != 0) return BadRequest(respuesta.mensaje);
                else respuesta.mensaje = "La contraseña fue cambiada exitosamente.";
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                //return StatusCode(500, ConstantesDeErrores.DevolverMensaje(ConstantesDeErrores.ErrorInesperadoActualizarContrasenia));
            }

            return Ok(respuesta.mensaje);
        }


        [HttpPut("EliminarUsuario")]
        public async Task<ActionResult<APIRespuestas>> Eliminar(int id)
        {
            APIRespuestas respuesta = new APIRespuestas();
            try
            {
                respuesta = await _usuariosService.BajaUsuario(id);

                if (respuesta.codigo != 0)
                {
                    return BadRequest(respuesta.mensaje);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ConstantesDeErrores.DevolverMensaje(ConstantesDeErrores.ErrorInesperadoEliminarCliente));
            }

            return Ok(respuesta);
        }

    }
}
