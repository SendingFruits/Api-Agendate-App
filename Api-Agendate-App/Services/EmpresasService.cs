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

        public async Task<APIRespuestas> CreateAsync(EmpresaDTO nuevaEmpresa)
        {
            try
            {
                var existe = await _EmpRepo.Obtener(emp => emp.RutDocumento == nuevaEmpresa.RutDocumento);

                if (existe != null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                    return _respuestas;
                }

                Empresa E = _Mapper.Map<Empresa>(nuevaEmpresa);
                await _EmpRepo.Crear(E);

                _respuestas.codigo = 0;

            }
            catch (Exception ex)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;
            }


            return _respuestas;
        }

        public APIRespuestas Update(EmpresaDTO entidad)
        {
            try
            {
                var empresaBD = _EmpRepo.Obtener(c => c.NombreUsuario == entidad.NombreUsuario);
                if (empresaBD == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;
                }
                Empresa empresaFinal = _Mapper.Map<Empresa>(entidad);

                _EmpRepo.Actualizar(empresaFinal);
                _respuestas.codigo = 0;

            }
            catch (Exception)
            {

                _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;
            }

            return _respuestas;
        }

        public async Task<APIRespuestas> GetEmpresas()
        {
            try
            {
                var EmpresasZona = await _EmpRepo.ObtenerTodos();
                if (!EmpresasZona.Any())
                {
                    _respuestas.Resultado = null;
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                }
                var Lista = _Mapper.Map<IEnumerable<EmpresaDTO>>(EmpresasZona).ToList();
                _respuestas.Resultado = Lista;
                return _respuestas;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return _respuestas;

        }

        public async Task<IEnumerable<EmpresaDTO>> ObtenerTodos()
        {
            try
            {
                IEnumerable<Empresa> EmpresasZona = await _EmpRepo.ObtenerTodos();
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

        public async Task<APIRespuestas> Delete(string p_NombreUsuario)
        {
            try
            {
                var existe = _EmpRepo.Obtener(emp => emp.NombreUsuario == p_NombreUsuario);
                if (existe == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;

                }
                await _EmpRepo.Remover(p_NombreUsuario);
                _respuestas.codigo = 0;
                
            }
            catch (Exception ex)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
            }

            return _respuestas;
        }


    }
}
