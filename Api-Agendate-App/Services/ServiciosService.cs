using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs.Empresas;
using Api_Agendate_App.DTOs.Horarios;
using Api_Agendate_App.DTOs.Servicio;
using Api_Agendate_App.Utilidades;
using AutoMapper;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Interfases;

namespace Api_Agendate_App.Services
{
    public class ServiciosService
    {

        private readonly IServicios _ServRepo;
        private readonly IEmpresa _EmpresaRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;

        public ServiciosService(IServicios servRepo, IEmpresa empresaRepo, IMapper mapper, APIRespuestas respuestas)
        {
            _ServRepo = servRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
            _EmpresaRepo = empresaRepo;
        }

        public async Task<APIRespuestas> Create([FromBody] ServicioDTO NuevoServicio)
        {
            var Existe = await _ServRepo.Obtener(ser => ser.Nombre == NuevoServicio.Nombre && ser.Empresa.Id == NuevoServicio.IdEmpresa);
            if (Existe != null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorYaExisteElNombreDelServicio;
                return _respuestas;
            }


            var existeEmpresa = await _EmpresaRepo.Obtener(emp => emp.Id == NuevoServicio.IdEmpresa);

            if (existeEmpresa == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                return _respuestas;
            }

            Servicios S = _Mapper.Map<Servicios>(NuevoServicio);

            var empresa = await _EmpresaRepo.Obtener(emp => emp.Id == S.EmpresaId);

            if (empresa != null)
                S.Empresa = empresa;

            await _ServRepo.Crear(S);

            return _respuestas;
        }

        public async Task<APIRespuestas> Delete(int id)
        {
            try
            {
                var existe = await _ServRepo.Obtener(s => s.Id == id && s.Activo == true);
                if (existe == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;

                }
                await _ServRepo.Remover(id);

            }
            catch (Exception ex)
            {
                _respuestas.codigo = 9999;
                _respuestas.mensaje = ex.Message;
            }
            return _respuestas;
        }

        public async Task<APIRespuestas> Update([FromBody] ServicioActualizarDTO entidad)
        {
            try
            {
                var servicioObtenido = await _ServRepo.Obtener(c => c.Id == entidad.Id && c.Activo == true);
                if (servicioObtenido == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;
                }

                ActualizarAtributos(ref servicioObtenido, entidad);
                await _ServRepo.Actualizar(servicioObtenido);

            }
            catch (Exception)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;
            }

            return _respuestas;

        }

        public async Task<IEnumerable<ServicioDTO>> GetServicios()
        {
            try
            {
                IEnumerable<Servicios> LServis = await _ServRepo.ObtenerTodos(s => s.Activo == true);
                IEnumerable<ServicioDTO> Lista = _Mapper.Map<IEnumerable<ServicioDTO>>(LServis);
                _respuestas.Resultado = Lista;
                return Lista;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return (IEnumerable<ServicioDTO>)_respuestas.Resultado;

        }

        public async Task<APIRespuestas> ObtenerServicioPorNombreEmpresa(string nombreEmp)
        {
            try
            {
                var Servis = await  _ServRepo.ObtenerTodos(i => i.Empresa.Nombre == nombreEmp && i.Activo == true);
                
                ServicioDTO EServ = _Mapper.Map<ServicioDTO>(Servis);
                _respuestas.Resultado = EServ;
                return _respuestas;
            }
            catch (Exception ex)
            {
                _respuestas.codigo = 9999;
                _respuestas.mensaje = ex.Message;
                return _respuestas;
            }
           
        }

        public async Task<APIRespuestas> ObtenerServicioPorIdEmpresa(int id)
        {
            try
            {
                var encontreServicio = await _ServRepo.Obtener(i => i.Empresa.Id == id && i.Activo == true);
                if (encontreServicio == null)
                {
                    _respuestas.Resultado = null;
                    _respuestas.codigo = ConstantesDeErrores.ErrorServicioNoEncontrado;
                    return _respuestas;
                }

                ServicioDTO EServ = _Mapper.Map<ServicioDTO>(encontreServicio);
                _respuestas.Resultado = EServ;
                return _respuestas;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;
                return null;
            }

        }

        private void ActualizarAtributos(ref Servicios servicioContext, ServicioActualizarDTO servicioMapeado)
        {
            try
            {
                if (servicioContext.Nombre != servicioMapeado.Nombre)
                    servicioContext.Nombre = servicioMapeado.Nombre;
                if (servicioContext.HoraInicio != servicioMapeado.HoraInicio)
                    servicioContext.HoraInicio = servicioMapeado.HoraInicio;
                if (servicioContext.HoraFin != servicioMapeado.HoraFin)
                    servicioContext.HoraFin = servicioMapeado.HoraFin;
                if (servicioContext.DiasDefinidosSemana != servicioMapeado.DiasDefinidosSemana)
                    servicioContext.DiasDefinidosSemana = servicioMapeado.DiasDefinidosSemana;
                if (servicioContext.DuracionTurno != servicioMapeado.DuracionTurno)
                    servicioContext.DuracionTurno = servicioMapeado.DuracionTurno;
                if (servicioContext.TipoServicio != servicioMapeado.TipoServicio)
                    servicioContext.TipoServicio = servicioMapeado.TipoServicio;
                if (servicioContext.Costo != servicioMapeado.Costo)
                    servicioContext.Costo = servicioMapeado.Costo;
                if (servicioContext.Descripcion != servicioMapeado.Descripcion)
                    servicioContext.Descripcion = servicioMapeado.Descripcion;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
