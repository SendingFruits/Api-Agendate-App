namespace Api_Agendate_App.Models
{
    public class MAgenda
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public MEmpresas empresaCreadora { get; set; }

        public MServicios servicioAsociado {get; set;}

        public DateTime fechaCreacion { get; set; }

        public int horaInicio { get; set; }

        public int horaFin { get; set; }

        public bool activa { get; set; }
    }
}
