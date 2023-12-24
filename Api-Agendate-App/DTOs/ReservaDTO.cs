using Api_Agendate_App.DTOs.Servicio;

namespace Api_Agendate_App.DTOs
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public ClienteDTO cliente { get; set; }
        public ServicioDTO servicio { get; set; }
        public DateTime horarioReserva { get; set; }
        public bool Estado { get; set; }
    }
}
