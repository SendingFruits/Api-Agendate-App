namespace Api_Agendate_App.Models
{
    public class MReservas
    {
        public MClientes cliente { get; set; }

        public MServicios servicio { get; set; }

        public DateTime horarioReserva { get; set; }


    }
}
