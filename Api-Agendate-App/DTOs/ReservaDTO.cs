
using Api_Agendate_App.Models;

namespace Api_Agendate_App.DTOs
{
    public class ReservaDTO
    {
        public ClienteDTO cliente { get; set; }

        public ServicioDTO servicio { get; set; }

        public DateTime horarioReserva { get; set; }


    }
}
