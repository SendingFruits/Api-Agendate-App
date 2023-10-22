using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs;
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
            }
            catch (Exception)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
            }

            return _respuestas;
        }

    }
}
