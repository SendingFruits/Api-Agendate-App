using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs.Horarios;
using Api_Agendate_App.DTOs.Reservas;
using Api_Agendate_App.DTOs.Servicio;
using Api_Agendate_App.Utilidades;
using AutoMapper;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Interfases;
using Repositorio.IRepositorio;

namespace Api_Agendate_App.Services
{
    public class ReservasService
    {

        private readonly IReserva _ReservaRepo;
        private readonly IServicios _ServiciosRepo;
        private readonly ICliente _ClienteRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;

        public ReservasService(IReserva reservRepo, ICliente clienteRepo, IMapper mapper, IServicios serviciosRepo, APIRespuestas respuestas)
        {
            _ReservaRepo = reservRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
            _ClienteRepo = clienteRepo;
            _ServiciosRepo = serviciosRepo;
        }

        public async Task<APIRespuestas> Create([FromBody] ReservaDTO nuevaReserva)
        {
            
            var existeCliente = await _ClienteRepo.Obtener(cli => cli.Id == nuevaReserva.IdCliente);

            if (existeCliente == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                return _respuestas;
            }

            var existeServicio = await _ServiciosRepo.Obtener(cli => cli.Id == nuevaReserva.IdCliente);

            if (existeServicio == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                return _respuestas;
            }

            var existeReserva = await _ReservaRepo.Obtener(res => res.FechaHoraReserva == nuevaReserva.fechaHoraReserva && res.ServicioId == nuevaReserva.IdServicio);
            
            if (existeReserva != null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorYaExisteTurnoReservado;
                return _respuestas;
            }

            Reservas reserva = _Mapper.Map<Reservas>(nuevaReserva);

            await _ReservaRepo.Crear(reserva);

            return _respuestas;
        }

        public async Task<APIRespuestas> Delete(int id)
        {
            try
            {
                var existe = await _ReservaRepo.Obtener(reserv => reserv.Id == id);
                if (existe == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;

                }

                await _ReservaRepo.Remover(id);

            }
            catch (Exception ex)
            {
                _respuestas.codigo = 9999;
                _respuestas.mensaje = ex.Message;
            }

            return _respuestas;
        }

        public async Task<APIRespuestas> Update([FromBody] ReservaDTO entidad)
        {
            try
            {
                var reservaObtenida = await _ReservaRepo.Obtener(c => c.Id == entidad.Id);
                if (reservaObtenida == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorEntidadInexistente;
                    return _respuestas;
                }

                if (reservaObtenida.Estado != entidad.Estado)
                {
                    reservaObtenida.Estado = entidad.Estado;

                    await _ReservaRepo.Actualizar(reservaObtenida);
                }
                else
                    _respuestas.mensaje = "No existen cambios en el estado.";
            }
            catch (Exception)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInsertandoEntidad;
            }

            return _respuestas;

        }

        public async Task<IEnumerable<ReservaDTO>> GetReservas()
        {
            try
            {
                IEnumerable<Reservas> lReservas = await _ReservaRepo.ObtenerTodos();
                IEnumerable<ReservaDTO> listaMapeada = _Mapper.Map<IEnumerable<ReservaDTO>>(lReservas);
                _respuestas.Resultado = listaMapeada;
                return listaMapeada;
            }
            catch (Exception ex)
            {
                _respuestas.mensaje = ex.Message;

            }
            return (IEnumerable<ReservaDTO>)_respuestas.Resultado;

        }

        public async Task<APIRespuestas> ObtenerHorariosSegunFecha(int idServicio, DateTime fecha)
        {
            var servicio = await _ServiciosRepo.Obtener(s => s.Id == idServicio);
            if (servicio == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorServicioNoEncontrado;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            var listaHorarios = await ObtenerHorariosServicioSegunFecha(servicio, fecha);

            if (listaHorarios == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInesperadoAlObtenerHorariosSegunFecha;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            _respuestas.Resultado = listaHorarios;
            return _respuestas;
        }

        private async Task<List<HorariosDTO>> ObtenerHorariosServicioSegunFecha (Servicios servicioAsociado, DateTime fechaAsociada)
        {
            List<HorariosDTO> listaHorarios = new List<HorariosDTO>();
            DateTime fechaDesde = CrearFechaSegunHoraDecimales(servicioAsociado.HoraInicio, fechaAsociada);
            DateTime fechaHasta = CrearFechaSegunHoraDecimales(servicioAsociado.HoraFin, fechaAsociada);
            var reservasParaLaFecha = await _ReservaRepo.ObtenerTodos(r => r.FechaHoraReserva >= fechaDesde && r.FechaHoraReserva <= fechaHasta);

            double horaSumarFechas = servicioAsociado.DuracionTurno == 30 ? 0.5 : 1;
            while (fechaDesde <= fechaHasta)
            {
                bool horarioDisponible = reservasParaLaFecha.Any(r => r.FechaHoraReserva == fechaDesde);
                listaHorarios.Add(new HorariosDTO(fechaDesde, horarioDisponible));
                if (servicioAsociado.DuracionTurno == 30)
                    horaSumarFechas += 0.5;
                else
                    horaSumarFechas++;

                fechaDesde.AddHours(horaSumarFechas);
            }

            return listaHorarios;
        }

        private DateTime CrearFechaSegunHoraDecimales(decimal hora, DateTime fechaBase)
        {
            // Multiplica las horas decimales por 60 para obtener los minutos
            int minutos = (int)(hora * 60);

            // Crea un objeto DateTime con una fecha base y agrega los minutos
            DateTime fecha = new DateTime(fechaBase.Year, fechaBase.Month, fechaBase.Day, minutos / 60, minutos % 60, 0);

            return fecha;
        }
    }
}
