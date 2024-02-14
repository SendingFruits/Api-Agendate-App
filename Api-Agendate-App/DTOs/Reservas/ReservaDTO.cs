using Api_Agendate_App.DTOs.Servicio;

namespace Api_Agendate_App.DTOs.Reservas
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaHoraTurno { get; set; }
        public string Estado { get; set; }
    }

    public class ReservasDeEmpresasDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaHoraTurno { get; set; }
        public string Estado { get; set; }
        public string NombreCliente { get; set; }

        public string ApellidoCliente { get; set; }

        public string CorreoCliente { get; set; }

        public string CelularCliente { get; set; }

        public string Documento { get; set; }
    }

    public class ReservasDeClientesDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaHoraTurno { get; set; }
        public string Estado { get; set; }
        public string NombreServicio { get; set; }

        public string JSONDiasHorariosDisponibilidadServicio { get; set; }

        public int DuracionTurno { get; set; }

        public decimal? Costo { get; set; }

        public string Descripcion { get; set; }

        public string NombreEmpresa { get; set; }

        public string Rubro { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string DescripcionEmpresa { get; set; }

        public string Celular { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }
    }
}
