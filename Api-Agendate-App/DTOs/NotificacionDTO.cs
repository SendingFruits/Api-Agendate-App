namespace Api_Agendate_App.Models
{
    public class NotificacionDTO
    {
        
        public string correoDestinatario { get; set; }

        public string asunto { get; set; } 

        public DateTime fechaEnvio { get; set; }

        public string cuerpo { get; set; }

    }
}
