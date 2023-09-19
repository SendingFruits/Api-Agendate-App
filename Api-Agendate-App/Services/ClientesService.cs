using Api_Agendate_App.Constantes;
using Api_Agendate_App.Models;
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
        private readonly IClienteRepositorio _CliRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;
        private readonly NotificacionesService _SNoticar;

        public ClientesService(IUsuario UsuRepo,IMapper mapper, APIRespuestas respuestas, IClienteRepositorio cliRepo, NotificacionesService sNoticar)
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
                var clienteRepo = await _CliRepo.Obtener(cli => cli.NombreUsuario == username && cli.Contrasenia == password);
                
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
                var esta = await _CliRepo.Obtener(cli => cli.Documento == p_nuevoCliente.documento);
                
                if (esta!= null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }
                Cliente cliente1= _Mapper.Map<Cliente>(p_nuevoCliente);
                await _CliRepo.Crear(cliente1);
                NotificacionDTO n = new NotificacionDTO
                {
                    asunto = "BIENVENIDO A AGENDATEAPP",
                    correoDestinatario = cliente1.Correo,
                    fechaEnvio = DateTime.Now,
                    cuerpo = "Gracias por registrarte en AgendateApp , estamos muy felices de que formes parte de esta comunidad. " +
                    "Aquí podras encontrar un mundo de Servicios a tú disposición. "

                };

                //await _SNoticar.CreateMail(n);
            }
            catch (Exception )
            {

                _respuestas.codigo= ConstantesDeErrores.ErrorInsertandoEntidad;
            }
            return _respuestas;
        }

        public async Task<ActionResult<APIRespuestas>> GetClientes()
        {
            try
            {
                IEnumerable<Cliente> UsuarioList = await _CliRepo.ObtenerTodos();
                IEnumerable<ClienteDTO> UsuariosList = _Mapper.Map<IEnumerable<ClienteDTO>>(UsuarioList);
               _respuestas.Resultado= UsuariosList;
                return _respuestas;

            }
            catch (Exception ex)
            {
                _respuestas.mensaje =  ex.ToString() ;
                _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;
            }
            return _respuestas;
        }

        public async Task<APIRespuestas> Update(ClienteDTO p_Modificacion)
        {
            try
            {
                var esta =  await _CliRepo.Obtener(c => c.NombreUsuario == p_Modificacion.NombreUsuario);
                if (esta== null)
                {
                    _respuestas.codigo= ConstantesDeErrores.ErrorEntidadInexistente;
                    _respuestas.ObtenerMensaje(_respuestas.codigo);
                    return _respuestas;
                }
                Cliente cliente1 = _Mapper.Map<Cliente>(p_Modificacion);

               await _CliRepo.Actualizar(cliente1);

            }
            catch (Exception )
            {

               _respuestas.codigo= ConstantesDeErrores.ErrorInsertandoEntidad;
            }
            return _respuestas;
        }

        public async Task<APIRespuestas> Buscar(string ci)
        {
            try
            {
                var encontre = await _CliRepo.Obtener(cli => cli.Documento == ci);
                if (encontre != null)
                {
                    _respuestas.codigo = 0;
                    _respuestas.Resultado = encontre;

                }


            }
            catch (Exception)
            {

                _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;

            }
            return _respuestas;
        }

        public async Task<APIRespuestas> Delete(int id)
        {
            try
            {
                var existe  = await _CliRepo.Obtener(cli => cli.Id == id);

                if (existe == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                await _CliRepo.Remover(id);
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
