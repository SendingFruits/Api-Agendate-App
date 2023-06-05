using Api_Agendate_App.Models;

namespace Logic.Models
{
    public class MAgendas
    {
        public int id { get; set; }

        public MEmpresas empresaCreadora { get; set; }

        private MServicios servicioAsociado {get; set;}

        public DateTime fechaCreacion { get; set; }

        public bool activa { get; set; }
    }
}
