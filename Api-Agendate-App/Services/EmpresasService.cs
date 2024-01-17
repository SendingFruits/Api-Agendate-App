using Api_Agendate_App.Constantes;
using Api_Agendate_App.Utilidades;
using Logic.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repositorio;
using Repositorio.Interfases;
using System.Collections.Generic;
using Api_Agendate_App.Logica;
using Api_Agendate_App.DTOs.Empresas;

namespace Api_Agendate_App.Services
{
    public class EmpresasService
    {
        private readonly IEmpresa _EmpRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;
        private readonly MensajeriaService _SNoticar;

        public EmpresasService(IEmpresa EmpRepo, IMapper mapper, APIRespuestas respuestas, MensajeriaService sNoticar)
        {
            _EmpRepo = EmpRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
            _SNoticar = sNoticar;
        }

        public async Task<EmpresaDTO> Login(string username, string password)
        {
            var empresaRepo = await _EmpRepo.Obtener(empe => empe.NombreUsuario == username && empe.Contrasenia == password);

            if (empresaRepo == null)
            {
                return null;
            }
            var empresa = _Mapper.Map<EmpresaDTO>(empresaRepo);
            return empresa;
        }

        public async Task<APIRespuestas> CreateAsync(EmpresaDTO nuevaEmpresa)
        {
            try
            {
                var existe = await _EmpRepo.Obtener(emp => emp.NombreUsuario == nuevaEmpresa.NombreUsuario);

                if (existe != null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEmpresaConUsuarioExistente;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                var empresaBD = await _EmpRepo.Obtener(c => c.RutDocumento == nuevaEmpresa.RutDocumento);
                if (empresaBD != null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEmpresaConDocumentoExistente;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                Empresas E = _Mapper.Map<Empresas>(nuevaEmpresa);
                await _EmpRepo.Crear(E);

                await _SNoticar.CreateMail(nuevaEmpresa.Correo);
            }
            catch (Exception ex)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;
            }
            return _respuestas;
        }

        public async Task<APIRespuestas> UpdateAsync(EmpresaDatosBasicosDTO entidad)
        {
            try
            {
                var empresaObtenida = await _EmpRepo.Obtener(c => c.Id == entidad.Id);
                if (empresaObtenida == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;
                }

                var empresaConRutIgual = await _EmpRepo.Obtener(c => c.RutDocumento == entidad.RutDocumento && c.Id != entidad.Id);
                if (empresaConRutIgual != null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEmpresaConDocumentoExistente;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                ActualizarAtributos(ref empresaObtenida, entidad);
                await _EmpRepo.Actualizar(empresaObtenida);

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

        public async Task<APIRespuestas> GetEmpresaPorId(int id)
        {
            try
            {
                var empresa = await _EmpRepo.Obtener(e => e.Id == id);
                if (empresa == null)
                {
                    _respuestas.Resultado = null;
                    _respuestas.codigo = ConstantesDeErrores.ErrorEmpresaNoEncontrada;
                }
                var empresaMapeada = _Mapper.Map<EmpresaDTO>(empresa);
                _respuestas.Resultado = empresaMapeada;
                return _respuestas;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return _respuestas;
        }

        public async Task<APIRespuestas> GetEmpresasMapa(float radioCircunferenciaUbicacion, float latitudeCli, float longitudeCli)
        {
            try
            {   
                var empresasZona = await _EmpRepo.ObtenerTodos();
                if (!empresasZona.Any())
                {
                    _respuestas.Resultado = null;
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                }
                var Lista = _Mapper.Map<IEnumerable<EmpresaMapaDTO>>(empresasZona);

                var empresasRadio = LogicaObtenerPuntosSegunRadio.EmpresasDentroDelRadio(Lista, longitudeCli, latitudeCli, radioCircunferenciaUbicacion);
                _respuestas.Resultado = empresasRadio;
                return _respuestas;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;
            }
            return _respuestas;
        }

        public async Task<APIRespuestas> Buscar(string rut)
        {
            try
            {
                var Esta = await _EmpRepo.Obtener(empre => empre.RutDocumento == rut);
                if(Esta==null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;
                }
                _respuestas.Resultado= Esta;

                return _respuestas;
            }
            catch (Exception)
            {

                _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;
                return _respuestas;
            }
        }

        public async Task<APIRespuestas> Delete(int id)
        {
            try
            {
                var existe = await _EmpRepo.Obtener(emp => emp.Id == id);
                if (existe == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;

                }
                await _EmpRepo.Remover(id);
                
            }
            catch (Exception ex)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
            }
            return _respuestas;
        }

        private void ActualizarAtributos(ref Empresas empresaContext, EmpresaDatosBasicosDTO empresaMapeada)
        {
            try
            {
                if (empresaContext.RutDocumento != empresaMapeada.RutDocumento)
                    empresaContext.RutDocumento = empresaMapeada.RutDocumento;
                if (empresaContext.RazonSocial != empresaMapeada.RazonSocial)
                    empresaContext.RazonSocial = empresaMapeada.RazonSocial;
                if (empresaContext.NombrePropietario != empresaMapeada.NombrePropietario)
                    empresaContext.NombrePropietario = empresaMapeada.NombrePropietario;
                if (empresaContext.Rubro != empresaMapeada.Rubro)
                    empresaContext.Rubro = empresaMapeada.Rubro;
                if (empresaContext.Direccion != empresaMapeada.Direccion)
                    empresaContext.Direccion = empresaMapeada.Direccion;
                if (empresaContext.Ciudad != empresaMapeada.Ciudad)
                    empresaContext.Ciudad = empresaMapeada.Ciudad;
                if (empresaContext.Descripcion != empresaMapeada.Descripcion)
                    empresaContext.Descripcion = empresaMapeada.Descripcion;
                if (empresaContext.Latitude != empresaMapeada.Latitude)
                    empresaContext.Latitude = empresaMapeada.Latitude;
                if (empresaContext.Longitude != empresaMapeada.Longitude)
                    empresaContext.Longitude = empresaMapeada.Longitude;
                if (empresaContext.Logo != empresaMapeada.Logo)
                    empresaContext.Logo = empresaMapeada.Logo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
