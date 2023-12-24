using Api_Agendate_App.DTOs.Empresas;
using Api_Agendate_App.DTOs.Servicio;

namespace Api_Agendate_App.DTOs
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
