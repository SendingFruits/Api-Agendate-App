namespace Api_Agendate_App.DTOs.Servicio
{
    public class ServicioActualizarDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string JSONDiasHorariosDisponibilidadServicio { get; set; }

        public int DuracionTurno { get; set; }

        public string TipoServicio { get; set; }

        public decimal? Costo { get; set; }

        public string Descripcion { get; set; }

    }
}
