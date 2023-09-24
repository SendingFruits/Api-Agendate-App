using Api_Agendate_App.Constantes;
using Api_Agendate_App.Models;
using Api_Agendate_App.Utilidades;
using Logic.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repositorio;
using Repositorio.Interfases;
using System.Collections.Generic;
using Api_Agendate_App.Logica;

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
                var existe = await _EmpRepo.Obtener(emp => emp.RutDocumento == nuevaEmpresa.RutDocumento);

                if (existe != null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                    return _respuestas;
                }

                Empresa E = _Mapper.Map<Empresa>(nuevaEmpresa);
                await _EmpRepo.Crear(E);

                string correoDestinatario = nuevaEmpresa.Correo;
                NotificacionDTO n = new NotificacionDTO
                {
                    asunto = "BIENVENIDO A AGENDATEAPP",
                    correoDestinatario = nuevaEmpresa.Correo,
                    fechaEnvio = DateTime.Now,
                    cuerpo = "Gracias por registrarte en AgendateApp , estamos muy felices de que formes parte de esta comunidad. " + "br/" +
                    "Aquí podras encontrar a muchos clientes  de tú zona buscando tu Servicio. "

                };
                //Enviamos mail de confirmación
                await _SNoticar.CreateMail(n);

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

                var empresasRadio = CalculadorDePuntosEnCircunferencia.EmpresasDentroDelRadio(Lista, longitudeCli, latitudeCli, radioCircunferenciaUbicacion);
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
                _respuestas.codigo = 0;

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
                var existe = _EmpRepo.Obtener(emp => emp.Id == id);
                if (existe == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;

                }
                await _EmpRepo.Remover(id);
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
