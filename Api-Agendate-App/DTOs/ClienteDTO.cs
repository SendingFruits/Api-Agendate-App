namespace Api_Agendate_App.DTOs
{
    public class ClienteDTO : UsuarioDTO
    {
        public string documento { get; set; }

        public bool tieneNotificaciones { get; set; }
    }
}
