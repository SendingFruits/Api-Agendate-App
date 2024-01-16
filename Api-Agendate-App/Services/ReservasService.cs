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
using System.Globalization;
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
        private readonly APIRespuestas _respuestas;

        public ReservasService(IReserva reservRepo, ICliente clienteRepo, IMapper mapper, IServicios serviciosRepo, IEmpresa empresaRepo, APIRespuestas respuestas)
        {
            _ReservaRepo = reservRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
            _ClienteRepo = clienteRepo;
            _ServiciosRepo = serviciosRepo;
            _EmpresaRepo = empresaRepo;
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

            var existeReserva = await _ReservaRepo.Obtener(res => res.FechaHoraTurno == nuevaReserva.FechaHoraTurno && res.ServicioId == nuevaReserva.IdServicio);
            
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

            string diaDeLaFechaSinTilde = DevolverDiaDeSemanaEspanol(fecha);

            if (!servicio.DiasDefinidosSemana.Contains(diaDeLaFechaSinTilde))
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

            DateTime fechaDesde = CrearFechaSegunHoraDecimales(servicio.HoraInicio, fecha);
            DateTime fechaHasta = CrearFechaSegunHoraDecimales(servicio.HoraFin, fecha);
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
                    CelularCliente = cliente.Celular
                });
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

            List<int> IDsEmpresas = serviciosReservas.Select(r => r.Empresa.Id).ToList();

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
                    NombreEmpresa = empresa.RazonSocial
                }); ;
            }

            _respuestas.Resultado = listaReservasCliente.OrderByDescending(r => r.FechaHoraTurno);
            return _respuestas;
        }

        private async Task<List<HorariosDTO>> ObtenerHorariosServicioSegunFecha (Servicios servicioAsociado, DateTime fechaAsociada)
        {
            List<HorariosDTO> listaHorarios = new List<HorariosDTO>();
            DateTime fechaDesde = CrearFechaSegunHoraDecimales(servicioAsociado.HoraInicio, fechaAsociada);
            DateTime fechaHasta = CrearFechaSegunHoraDecimales(servicioAsociado.HoraFin, fechaAsociada);
            var reservasParaLaFecha = await _ReservaRepo.ObtenerTodos(r => r.FechaHoraTurno >= fechaDesde && r.FechaHoraTurno <= fechaHasta);

            double horaSumarFechas = servicioAsociado.DuracionTurno == 30 ? 0.5 : 1;
            while (fechaDesde < fechaHasta)
            {
                bool horarioDisponible = !reservasParaLaFecha.Any(r => r.FechaHoraTurno == fechaDesde);
                listaHorarios.Add(new HorariosDTO(fechaDesde, horarioDisponible));
                fechaDesde = fechaDesde.AddHours(horaSumarFechas);
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

        private string DevolverDiaDeSemanaEspanol (DateTime fecha)
        {
            DayOfWeek diaDeLaFecha = fecha.DayOfWeek;
            switch (diaDeLaFecha)
            {
                case DayOfWeek.Sunday:
                    return "Domingo";
                case DayOfWeek.Monday:
                    return "Lunes";
                case DayOfWeek.Tuesday:
                    return "Martes";
                case DayOfWeek.Wednesday:
                    return "Miercoles";
                case DayOfWeek.Thursday:
                    return "Jueves";
                case DayOfWeek.Friday:
                    return "Viernes";
                case DayOfWeek.Saturday:
                    return "Sabado";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
