using Api_Agendate_App.Constantes;
using Api_Agendate_App.Models;
using Api_Agendate_App.Utilidades;
using Logic.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repositorio;
using Repositorio.Interfases;
using System.Collections.Generic;

namespace Api_Agendate_App.Services
{
   
    public class EmpresasService
    {
        private readonly IEmpresa _EmpRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;
        public EmpresasService(IEmpresa EmpRepo, IMapper mapper, APIRespuestas respuestas)
        {
            _EmpRepo = EmpRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
        }


       public EmpresaDTO? Login(string username, string password)
          { 
              var empresas = _EmpRepo.Obtener(empe => empe.NombreUsuario == username && empe.Contrasenia == password);
             
              if (empresas == null)
              {
                 return null;
              }
              EmpresaDTO Encontre = _Mapper.Map<EmpresaDTO>(empresas);
              return Encontre;

           }

        public APIRespuestas Create([FromBody]EmpresaDTO nuevaEmpresa)
        {
            var Existe = _EmpRepo.Obtener(emp => emp.RutDocumento == nuevaEmpresa.RutDocumento);
           
            if (Existe != null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                return _respuestas;
            }

            Empresa E = _Mapper.Map<Empresa>(nuevaEmpresa);
            _EmpRepo.Crear(E);

            _respuestas.codigo = ConstantesDeErrores.Exito;

            return _respuestas;
        }

        public APIRespuestas Update([FromBody]EmpresaDTO entidad)
        {
            try
            {
                var Actualizo = _EmpRepo.Obtener(e => e.Id == entidad.Id);
                if (Actualizo != null)
                {
                         var empresa = new Empresa
                         {
                                        Id = entidad.Id,
                                        Nombre = entidad.Nombre,
                                        //Logo = entidad.Logo,
                                        Calle = entidad.Calle,
                                        Celular = entidad.Celular,
                                        Contrasenia = entidad.Contrasenia,
                                        NombreUsuario = entidad.NombreUsuario,
                                        RutDocumento = entidad.RutDocumento,
                                        RazonSocial = entidad.RazonSocial,
                                        Descripcion = entidad.Descripcion,
                                        Apellido = entidad.Apellido,
                                        Ciudad = entidad.Ciudad,
                                        Correo = entidad.Correo,
                                        Latitud = entidad.Latitud,
                                        NumeroPuerta = entidad.NumeroPuerta,
                                        Longitud = entidad.Longitud,
                                        NombrePropietario = entidad.NombrePropietario,
                                        Rubro = entidad.Rubro
                         };
            
                                     _EmpRepo.Actualizar(empresa);
                                   
                                    
                                     _respuestas.codigo = ConstantesDeErrores.Exito;
               
                                    

                }
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;


            }
            catch (Exception)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;

            }
           
           
            return _respuestas;

        }



        public async Task <IEnumerable<EmpresaDTO>> GetEmpresas()
        {
            try
            {
                IEnumerable<Empresa> EmpresasZona = await _EmpRepo.ObtenerTodos();
                IEnumerable<EmpresaDTO> Lista = _Mapper.Map<IEnumerable<EmpresaDTO>>(EmpresasZona);
                _respuestas.Resultado = Lista;
                return Lista;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return (IEnumerable<EmpresaDTO>)_respuestas.Resultado;

        }
        public async Task<IEnumerable<EmpresaDTO>> ObtenerTodos(decimal LongitudCli, decimal latituCli)
        {
            try
            {
                IEnumerable<Empresa> EmpresasZona = await _EmpRepo.ObtenerTodos(e=>e.Longitud >=  LongitudCli || e.Latitud<= latituCli);
                IEnumerable <EmpresaDTO> Lista = _Mapper.Map<IEnumerable<EmpresaDTO>>(EmpresasZona);
                _respuestas.Resultado = Lista;
                return Lista;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;
               
            }
            return (IEnumerable<EmpresaDTO>)_respuestas.Resultado;
        }

        public APIRespuestas Delete([FromBody] EmpresaDTO NEmpresa)
        {
            var existe = _EmpRepo.Obtener(cli => cli.RutDocumento == NEmpresa.RutDocumento);
            if (existe != null)
            {
                Empresa C = _Mapper.Map<Empresa>(NEmpresa);
                _EmpRepo.Remover(C);
                _respuestas.codigo = ConstantesDeErrores.Exito;
                return _respuestas;
            }




            _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;

            return _respuestas;
        }


    }
}
