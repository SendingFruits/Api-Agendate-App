namespace Api_Agendate_App.Models
{
    public class AgendaDTO
    {
        public int id { get; set; }

        public EmpresaDTO empresaCreadora { get; set; }

        private ServicioDTO servicioAsociado {get; set;}

        public DateTime fechaCreacion { get; set; }

        public bool activa { get; set; }
    }
}
