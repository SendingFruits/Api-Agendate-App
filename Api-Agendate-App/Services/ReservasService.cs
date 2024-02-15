using Api_Agendate_App.Constantes;
using Api_Agendate_App.DTOs.Horarios;
using Api_Agendate_App.DTOs.Reservas;
using Api_Agendate_App.DTOs.Servicio;
using Api_Agendate_App.Utilidades;
using AutoMapper;
using Logic.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repositorio.Interfases;
using Repositorio.IRepositorio;
using System;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Api_Agendate_App.Services
{
    public class ReservasService
    {

        private readonly IReserva _ReservaRepo;
        private readonly IServicios _ServiciosRepo;
        private readonly ICliente _ClienteRepo;
        private readonly IEmpresa _EmpresaRepo;
        private readonly IMapper _Mapper;

        private readonly MensajeriaService _SNoticar;
        private readonly APIRespuestas _respuestas;

        public ReservasService(IReserva reservRepo, ICliente clienteRepo, IMapper mapper, IServicios serviciosRepo, IEmpresa empresaRepo, APIRespuestas respuestas, MensajeriaService sNoticar)
        {
            _ReservaRepo = reservRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
            _ClienteRepo = clienteRepo;
            _ServiciosRepo = serviciosRepo;
            _EmpresaRepo = empresaRepo;
            _SNoticar = sNoticar;
        }

        public async Task<APIRespuestas> Create([FromBody] ReservaDTO nuevaReserva)
        {
            //La fecha del turno debe ser mayor a la fecha actual
            if (nuevaReserva.FechaHoraTurno < DateTime.Now)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorCrearReservaTurnoSeleccionadoVencido;
                return _respuestas;
            }

            #region Corroboracion de existencia de las relaciones ->
            var cliente = await _ClienteRepo.Obtener(cli => cli.Id == nuevaReserva.IdCliente);
            if (cliente == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorClienteConIdNoEncontrado;
                return _respuestas;
            }

            var servicio = await _ServiciosRepo.Obtener(srv => srv.Id == nuevaReserva.IdServicio);
            if (servicio == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorServicioConIdNoEncontrado;
                return _respuestas;
            }

            var emp = await _EmpresaRepo.Obtener(srv => srv.Id == servicio.EmpresaId);
            if (emp == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEmpresaNoEncontrada;
                return _respuestas;
            }

            #endregion
            string diaDeLaReserva = UtilidadesParaFechas.DevolverDiaDeSemanaEspanol(nuevaReserva.FechaHoraTurno);
            HorarioSemana horarioServicio = JsonConvert.DeserializeObject<HorarioSemana>(servicio.JSONDiasHorariosDisponibilidadServicio);
            PropertyInfo propiedadDia = horarioServicio.GetType().GetProperty(diaDeLaReserva);
            var dia = (HorarioDia)propiedadDia.GetValue(horarioServicio);
            if (dia.HoraInicio == null || dia.HoraFin == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorDiasDefinidosServicioNoMatcheaFechaReserva;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            //Fecha del turno esta dentro del rango del horario del servicio
            if (!FechaTurnoCorrectaParaRangoHorarioServicio((decimal)dia.HoraInicio, (decimal)dia.HoraFin,nuevaReserva.FechaHoraTurno))
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorHorarioTurnoNoEstaDentroDelRangoHorarioServicio;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            var existeReserva = await _ReservaRepo.Obtener(res => res.FechaHoraTurno == nuevaReserva.FechaHoraTurno && res.ServicioId == nuevaReserva.IdServicio && res.Estado != ConstantesReservas.EstadoReservaCancelada );
            if (existeReserva != null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorYaExisteTurnoReservado;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            nuevaReserva.Estado = ConstantesReservas.EstadoReservaSolicitada;
            Reservas reserva = _Mapper.Map<Reservas>(nuevaReserva);
            reserva.FechaRealizada = DateTime.Now;
            await _ReservaRepo.Crear(reserva);

            await _SNoticar.CreateMail(cliente.Correo, NotificacionesReserva.ObtenerAsuntoReservaExitosa(emp.RazonSocial), 
                                        NotificacionesReserva.ObtenerCuerpoReservaExitosa(cliente.Nombre, servicio.Nombre, reserva.FechaHoraTurno, emp.RazonSocial, emp.Direccion, emp.Celular, emp.Correo));
            
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

        public async Task<APIRespuestas> CancelarReserva(int idReserva)
        {
            try
            {
                var reserva = await _ReservaRepo.Obtener(r => r.Id == idReserva);
                if (reserva == null)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorNoExisteReservaSegunId;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                if (reserva.FechaHoraTurno < DateTime.Now)
                {
                    _respuestas.codigo = ConstantesDeErrores.ErrorTurnoReservaAntiguoAlCancelar;
                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                //Si es diferente de solicitada, no se puede modificar.
                if (reserva.Estado != ConstantesReservas.EstadoReservaSolicitada)
                {
                    switch (reserva.Estado)
                    {
                        case ConstantesReservas.EstadoReservaCancelada:
                            _respuestas.codigo = ConstantesDeErrores.ErrorLaReservaYaEstaCancelada;
                            break;
                        case ConstantesReservas.EstadoReservaRealizada:
                            _respuestas.codigo = ConstantesDeErrores.ErrorLaReservaYaEstaRealizada;
                            break;
                        case ConstantesReservas.EstadoReservaRechazada:
                            _respuestas.codigo = ConstantesDeErrores.ErrorLaReservaYaEstaRechazada;
                            break;
                    }

                    _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                    return _respuestas;
                }

                reserva.Estado = ConstantesReservas.EstadoReservaCancelada;
                await _ReservaRepo.Actualizar(reserva);
            }
            catch (Exception ex)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInesperadoAlCancelarReserva;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            return _respuestas;
        }

        public async Task<APIRespuestas> CambiarEstadoReserva(int idReserva, string nuevoEstado)
        {
            var reserva = await _ReservaRepo.Obtener(r => r.Id == idReserva);
            if (reserva == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorNoExisteReservaSegunId;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            if (nuevoEstado != ConstantesReservas.EstadoReservaCancelada && nuevoEstado != ConstantesReservas.EstadoReservaRechazada && 
                nuevoEstado != ConstantesReservas.EstadoReservaSolicitada && nuevoEstado != ConstantesReservas.EstadoReservaRealizada)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEstadoIngresadoNoEsCorrecto;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
                
            }
            
            if (nuevoEstado == ConstantesReservas.EstadoReservaCancelada)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorEmpresasNoPuedenCancelarReservas;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            if (nuevoEstado == reserva.Estado)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorLaReservaYaTieneEseEstado;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }


            reserva.Estado = nuevoEstado;
            await _ReservaRepo.Actualizar(reserva);

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

            string diaDeLaFechaSinTilde = UtilidadesParaFechas.DevolverDiaDeSemanaEspanol(fecha);
            HorarioSemana horario = JsonConvert.DeserializeObject<HorarioSemana>(servicio.JSONDiasHorariosDisponibilidadServicio);
            PropertyInfo propiedadDia = horario.GetType().GetProperty(diaDeLaFechaSinTilde);

            var dia = (HorarioDia)propiedadDia.GetValue(horario);
            if (dia.HoraInicio == null || dia.HoraFin == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorDiasDefinidosServicioNoMatcheaFechaReserva;
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

            if (listaHorarios.Count() == 0)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorNoHayHorariosDisponiblesParaLaFecha;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            _respuestas.Resultado = listaHorarios;
            return _respuestas;
        }

        public async Task<APIRespuestas> ObtenerReservasSegunFechaParaEmpresas(int idServicio, DateTime fecha)
        {
            var servicio = await _ServiciosRepo.Obtener(s => s.Id == idServicio);
            if (servicio == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorServicioNoEncontrado;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            string diaDeLaFechaSinTilde = UtilidadesParaFechas.DevolverDiaDeSemanaEspanol(fecha);
            HorarioSemana horario = JsonConvert.DeserializeObject<HorarioSemana>(servicio.JSONDiasHorariosDisponibilidadServicio);
            PropertyInfo propiedadDia = horario.GetType().GetProperty(diaDeLaFechaSinTilde);

            var dia = (HorarioDia)propiedadDia.GetValue(horario);
            if (dia.HoraInicio == null || dia.HoraFin == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorDiasDefinidosServicioNoMatcheaFechaReserva;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            DateTime fechaDesde = CrearFechaSegunHoraDecimales((decimal)dia.HoraInicio, fecha);
            DateTime fechaHasta = CrearFechaSegunHoraDecimales((decimal)dia.HoraFin, fecha);
            var reservasServicio = await _ReservaRepo.ObtenerTodos(r => r.ServicioId == idServicio && r.FechaHoraTurno >= fechaDesde && r.FechaHoraTurno <= fechaHasta);
            if (reservasServicio == null && reservasServicio.Count() == 0)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorNoExistenReservasParaLaFechaDada;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            List<int> IDsClientes = reservasServicio.Select(r => r.ClienteId).ToList();

            var clientes = await _ClienteRepo.ObtenerTodos(c => IDsClientes.Contains(c.Id));

            List<ReservasDeEmpresasDTO> listaReservasEmpresa = new List<ReservasDeEmpresasDTO>();
            
            foreach (var reserva in reservasServicio)
            {
                var cliente = clientes.FirstOrDefault(c => c.Id == reserva.ClienteId);
                listaReservasEmpresa.Add(new ReservasDeEmpresasDTO
                {
                    Id = reserva.Id,
                    IdCliente = reserva.ClienteId,
                    IdServicio = reserva.ServicioId,
                    FechaHoraTurno = reserva.FechaHoraTurno,
                    Estado = reserva.Estado,
                    NombreCliente = cliente.Nombre,
                    ApellidoCliente = cliente.Apellido,
                    CorreoCliente = cliente.Correo,
                    CelularCliente = cliente.Celular,
                    Documento = cliente.Documento
                }); ;
            }

            _respuestas.Resultado = listaReservasEmpresa.OrderByDescending(r => r.FechaHoraTurno); ;
            return _respuestas;
        }

        public async Task<APIRespuestas> ObtenerReservasParaClientes(int idCliente)
        {
            var cliente = await _ServiciosRepo.Obtener(s => s.Id == idCliente);
            if (cliente == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorClienteConIdNoEncontrado;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            var reservasCliente = await _ReservaRepo.ObtenerTodos(r => r.ClienteId == cliente.Id);
            if (reservasCliente == null && reservasCliente.Count() == 0)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorNoExistenReservasParaElIdCliente;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return _respuestas;
            }

            List<int> IDsServicios = reservasCliente.Select(r => r.ServicioId).ToList();

            var serviciosReservas = await _ServiciosRepo.ObtenerTodos(c => IDsServicios.Contains(c.Id));

            List<int> IDsEmpresas = serviciosReservas.Select(r => r.EmpresaId).ToList();

            var empresasReservas = await _EmpresaRepo.ObtenerTodos(c => IDsEmpresas.Contains(c.Id));

            List<ReservasDeClientesDTO> listaReservasCliente = new List<ReservasDeClientesDTO>();

            foreach (var reserva in reservasCliente)
            {
                var servicio = serviciosReservas.FirstOrDefault(s => s.Id == reserva.ServicioId);
                var empresa = empresasReservas.FirstOrDefault(s => s.Id == servicio.Empresa.Id);
                listaReservasCliente.Add(new ReservasDeClientesDTO
                {
                    Id = reserva.Id,
                    IdCliente = reserva.ClienteId,
                    IdServicio = reserva.ServicioId,
                    FechaHoraTurno = reserva.FechaHoraTurno,
                    Estado = reserva.Estado,
                    NombreServicio = servicio.Nombre,
                    JSONDiasHorariosDisponibilidadServicio = servicio.JSONDiasHorariosDisponibilidadServicio,
                    DuracionTurno = servicio.DuracionTurno,
                    Costo = servicio.Costo,
                    Descripcion = servicio.Descripcion,
                    NombreEmpresa = empresa.RazonSocial,
                    Rubro = empresa.Rubro,
                    Direccion = empresa.Direccion,
                    Ciudad = empresa.Ciudad,
                    DescripcionEmpresa = empresa.Descripcion,
                    Celular = empresa.Celular,
                    Latitude = empresa.Latitude,
                    Longitude = empresa.Longitude
                }); ;
            }

            _respuestas.Resultado = listaReservasCliente.OrderByDescending(r => r.FechaHoraTurno);
            return _respuestas;
        }

        /// <summary>
        /// Metodo que obtiene los horarios segun una fecha y un servicio asociado.
        /// <para></para>
        /// Parte de la fecha de inicio del servicio para iterar hasta la fecha de fin del mismo. Iterando y sumando a la fecha de inicio el intervalo (duracion del turno)
        /// En cada iteracion, se creara un horario. Que se devolvera en la lista siempre y cuando la fecha y hora de ese horario > a la fecha actual (Datetime.Now).
        /// <para></para>
        /// El horario estara disponible (en TRUE) siempre y cuando no haya un turno reservado para dicho horario y el mismo sea != Cancelado
        /// </summary>
        /// <param name="servicioAsociado"></param>
        /// <param name="fechaAsociada"></param>
        /// <returns>Una lista de HorariosDTO. Excluyendo los horarios menores a la fecha y la hora actual</returns>
        private async Task<List<HorariosDTO>> ObtenerHorariosServicioSegunFecha(Servicios servicioAsociado, DateTime diaDeConsulta)
        {
            List<HorariosDTO> listaHorarios = new List<HorariosDTO>();
            string diaDeLaFechaSinTilde = UtilidadesParaFechas.DevolverDiaDeSemanaEspanol(diaDeConsulta);
            HorarioSemana horario = JsonConvert.DeserializeObject<HorarioSemana>(servicioAsociado.JSONDiasHorariosDisponibilidadServicio);
            PropertyInfo propiedadDia = horario.GetType().GetProperty(diaDeLaFechaSinTilde);

            var dia = (HorarioDia)propiedadDia.GetValue(horario);
            if (dia.HoraInicio == null || dia.HoraFin == null)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorDiasDefinidosServicioNoMatcheaFechaReserva;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return null;
            }
            DateTime fechaPosibleTurno = CrearFechaSegunHoraDecimales((decimal)dia.HoraInicio, diaDeConsulta); //Parto del horario inicio del servicio
            DateTime fechaHastaPosibleHorario = CrearFechaSegunHoraDecimales((decimal)dia.HoraFin, diaDeConsulta);

            var reservasParaLaFecha = await _ReservaRepo.ObtenerTodos(r => r.FechaHoraTurno >= fechaPosibleTurno && r.FechaHoraTurno <= fechaHastaPosibleHorario);
            double intervaloHorarioServicio = servicioAsociado.DuracionTurno == 30 ? 0.5 : 1;

            while (fechaPosibleTurno < fechaHastaPosibleHorario) //Itero desde la fechaDesde hasta la fechaHasta del servicio. Para ir creando todos los horarios segun la duracion del servicio
            {
                if (fechaPosibleTurno > DateTime.Now) //La fechaDesde (horario x) debe ser mayor a hoy, sino no voy a devolver un turno
                {
                    //Si existe una reserva para la fecha y la misma no esta cancelada ==> Horario no disponible
                    bool horarioDisponible = !reservasParaLaFecha.Any(r => r.FechaHoraTurno == fechaPosibleTurno && r.Estado != ConstantesReservas.EstadoReservaCancelada);
                    listaHorarios.Add(new HorariosDTO(fechaPosibleTurno, horarioDisponible));
                }

                fechaPosibleTurno = fechaPosibleTurno.AddHours(intervaloHorarioServicio);
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

        /// <summary>
        /// Corrobora si la horaTurno esta dentro del rango de horario del servicio
        /// </summary>
        /// <param name="servicioHoraInicio"></param>
        /// <param name="servicioHoraFin"></param>
        /// <param name="horaTurno"></param>
        /// <returns>TRUE si esta dentro del rango, FALSE en caso contrario</returns>
        private bool FechaTurnoCorrectaParaRangoHorarioServicio(decimal servicioHoraInicio, decimal servicioHoraFin, DateTime horaTurno)
        {
            DateTime horaInicioServicio = CrearFechaSegunHoraDecimales(servicioHoraInicio, horaTurno);
            DateTime horaFinServicio = CrearFechaSegunHoraDecimales(servicioHoraFin, horaTurno);

            return horaTurno >= horaInicioServicio && horaTurno <= horaFinServicio;
        }


    }
}
