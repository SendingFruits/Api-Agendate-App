namespace Api_Agendate_App.DTOs
{
    public class ServicioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public decimal costo { get; set; }

        public int cupos { get; set; }

        public int frecuencia { get; set; }

    }
}
