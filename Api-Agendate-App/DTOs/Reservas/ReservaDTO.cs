using Api_Agendate_App.DTOs.Servicio;

namespace Api_Agendate_App.DTOs.Reservas
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
        public DateTime fechaHoraReserva { get; set; }
        public string Estado { get; set; }
    }
}
