using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs;
using Api_Agendate_App.DTOs.Usuarios;
using Api_Agendate_App.Seguridad;
using Api_Agendate_App.Utilidades;
using AutoMapper;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositorio.IRepositorio;

namespace Api_Agendate_App.Services
{
    public class UsuariosService
    {

        private readonly IUsuario _UsuRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;
        private readonly MensajeriaService _SNoticar;

        public UsuariosService(IUsuario UsuRepo, IMapper mapper, APIRespuestas respuestas, MensajeriaService sNoticar)
        {
            _Mapper = mapper;
            _respuestas = respuestas;
            _UsuRepo = UsuRepo;
            _SNoticar = sNoticar;
        }

        public async Task<APIRespuestas> ModificarContrasenia(int id, string passVieja, string passNueva)
        {
            try
            { 
                var usuario = await _UsuRepo.Obtener(u => u.Id == id);

                if (usuario == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                string passViejaEncriptada = Encriptadores.Encriptar(passVieja);
                usuario = await _UsuRepo.Obtener(u => u.Id == id && u.Contrasenia == passViejaEncriptada);

                if (usuario == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorContraseniaViejaNoCoincide;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                passNueva = Encriptadores.Encriptar(passNueva);
                usuario.Contrasenia = passNueva;
                await _UsuRepo.Actualizar(usuario);
                await _SNoticar.CreateMail(usuario.Correo, NotificacionesImportantes.ObtenerAsuntoCambioContrasenia(), NotificacionesImportantes.ObtenerCuerpoModificacionContrasenia(usuario.Nombre));

            }
            catch (Exception)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
            }

            return _respuestas;
        }

        public async Task<APIRespuestas> ActualizarDatosBasicosUsuario(UsuarioDatosBasicosDTO usuario)
        {

            try
            {
                var esta = await _UsuRepo.Obtener(c => c.Id == usuario.Id);
                if (esta == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    _respuestas.ObtenerMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                ActualizarAtributos(ref esta,usuario);
                await _UsuRepo.Actualizar(esta);

            }
            catch (Exception)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInesperadoActualizarUsuario;
            }
            return _respuestas;
        }

        private void ActualizarAtributos(ref Usuarios entidadBase, UsuarioDatosBasicosDTO entidadModificada)
        {
            try
            {
                if (entidadBase.Nombre != entidadModificada.Nombre)
                {
                    entidadBase.Nombre = entidadModificada.Nombre;
                }
                if (entidadBase.Apellido != entidadModificada.Apellido)
                {
                    entidadBase.Apellido = entidadModificada.Apellido;
                }
                if (entidadBase.Correo != entidadModificada.Correo)
                {
                    entidadBase.Correo = entidadModificada.Correo;
                }
                if (entidadBase.Celular != entidadModificada.Celular)
                {
                    entidadBase.Celular = entidadModificada.Celular;
                }


                //falta la foto 
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<APIRespuestas> BajaUsuario(int id)
        {
            try
            {
                var existe = await _UsuRepo.Obtener(u => u.Id == id && u.Activo == true);

                if (existe == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorClienteConIdNoEncontrado;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                existe.Activo = false;
                await _UsuRepo.Actualizar(existe);
                return _respuestas;
            }
            catch (Exception)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
            }
            return _respuestas;
        }
    }
}
