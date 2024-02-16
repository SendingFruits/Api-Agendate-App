using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs;
using Api_Agendate_App.Utilidades;
using AutoMapper;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositorio.IRepositorio;

namespace Api_Agendate_App.Services
{
    public class ClientesService
    {
        
        private readonly IUsuario _UsuRepo;
        private readonly ICliente _CliRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;
        private readonly MensajeriaService _SNoticar;

        public ClientesService(IUsuario UsuRepo,IMapper mapper, APIRespuestas respuestas, ICliente cliRepo, MensajeriaService sNoticar)
        {
            _Mapper = mapper;
            _respuestas = respuestas;
            _UsuRepo = UsuRepo;
            _CliRepo = cliRepo;
            _SNoticar = sNoticar;
        }

        public async Task<ClienteDTO> Login(string username, string password)
        {
            try
            {
                var clienteRepo = await _CliRepo.Obtener(cli => cli.NombreUsuario == username && cli.Contrasenia == password && cli.Activo == true);
                
                if (clienteRepo == null) 
                {
                    return null;
                }

                ClienteDTO cliente = _Mapper.Map<ClienteDTO>(clienteRepo);
                return cliente;

            }
            catch (Exception ex)
            {
                throw new Exception ("Ocurrio un error al intentar encontrar el cliente: " + ex) ;
            }
            
        }

        public async Task<APIRespuestas> CreateAsync(ClienteDTO p_nuevoCliente)
        {
            try
            {
                var esta = await _UsuRepo.Obtener(cli => cli.NombreUsuario == p_nuevoCliente.NombreUsuario);
                
                if (esta != null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorClienteConUsuarioExistente;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                var usuarioDocumento = await _CliRepo.Obtener(c => c.Documento == p_nuevoCliente.documento);
                if (usuarioDocumento != null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorClienteConDocumentoExistente;
                    _respuestas.ObtenerMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                Clientes cliente1= _Mapper.Map<Clientes>(p_nuevoCliente);
                await _CliRepo.Crear(cliente1);
                
                await _SNoticar.CreateMail(p_nuevoCliente.Correo, NotificacionesRegistro.AsuntoRegistro, NotificacionesRegistro.ObtenerCuerpoRegistro(p_nuevoCliente.Nombre));
                _respuestas.codigo = 0;
            }
            catch (Exception )
            {

                _respuestas.codigo= ConstantesDeErrores.ErrorInsertandoEntidad;
            }
            return _respuestas;
        }

        public async Task<APIRespuestas> ModificarNotificaciones(int idCliente, bool notificaciones)
        {
            try
            {
                var esta = await _CliRepo.Obtener(cli => cli.Id == idCliente && cli.Activo == true);

                if (esta == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorClienteConIdNoEncontrado;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                esta.tieneNotificaciones = notificaciones;
                await _CliRepo.Actualizar(esta);
            }
            catch (Exception)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInesperadoActualizarCliente;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }
            return _respuestas;
        }
        
    }
}
