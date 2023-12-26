namespace Api_Agendate_App.DTOs.Servicio
{
    public class ServicioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public decimal HoraInicio { get; set; }

        public decimal HoraFin { get; set; }

        public string DiasDefinidosSemana { get; set; }

        public int DuracionTurno { get; set; }

        public string TipoServicio { get; set; }

        public decimal? Costo { get; set; }

        public string Descripcion { get; set; }

        public int IdEmpresa { get; set; }

    }
}
