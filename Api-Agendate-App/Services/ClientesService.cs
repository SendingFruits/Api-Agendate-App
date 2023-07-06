using Api_Agendate_App.Constantes;
using Api_Agendate_App.Models;
using Api_Agendate_App.Utilidades;
using AutoMapper;
using Azure;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Interfases;
using Repositorio.IRepositorio;

namespace Api_Agendate_App.Services
{
    public class ClientesService
    {
        
        private readonly IUsuario _UsuRepo;
        private readonly IClienteRepositorio _CliRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;

        public ClientesService(IUsuario UsuRepo,IMapper mapper, APIRespuestas respuestas, IClienteRepositorio cliRepo)
        {
            _Mapper = mapper;
            _respuestas = respuestas;
            _UsuRepo = UsuRepo;
            _CliRepo = cliRepo;
        }


        public ClienteDTO Login(string username, string password)
        {
            var clientes = _CliRepo.Obtener(cli => cli.NombreUsuario == username && cli.Contrasenia == password);
            if (clientes == null)
            {
                return null;
            }
            ClienteDTO unCliente = _Mapper.Map<ClienteDTO>(clientes);
            return unCliente;
        }
        public async Task<APIRespuestas> CreateAsync(ClienteDTO p_nuevoCliente)
        {

            try
            {
                
                if (await _CliRepo.Obtener(cli => cli.Documento == p_nuevoCliente.documento)!= null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                    return _respuestas;
                }
                Cliente cliente1= _Mapper.Map<Cliente>(p_nuevoCliente);
               await _CliRepo.Crear(cliente1);
               _respuestas.codigo = ConstantesDeErrores.Exito;


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
                _respuestas.Resultado = _Mapper.Map<IEnumerable<ClienteDTO>>(UsuarioList);
              
                return _respuestas;

            }
            catch (Exception ex)
            {

                
                _respuestas.mensaje =  ex.ToString() ;
                _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;
            }
            return _respuestas;
        }


        public APIRespuestas Update( ClienteDTO p_Modificacion)
        {

            try
            { 
                if (_CliRepo.Obtener(c=> c.Id == p_Modificacion.Id)== null)
                {
                    _respuestas.codigo= ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;
                }
                Cliente cliente1 = _Mapper.Map<Cliente>(p_Modificacion);

                _CliRepo.Actualizar(cliente1);
                _respuestas.codigo = ConstantesDeErrores.Exito;

            }
            catch (Exception )
            {

               _respuestas.codigo= ConstantesDeErrores.ErrorInsertandoEntidad ;
            }
           
            return _respuestas;
        }

    }
}
