using Api_Agendate_App.DTOs.Usuarios;

namespace Api_Agendate_App.Models
{
    public class ClienteDTO : UsuarioDTO
    {
        public string documento { get; set; }

        //public string foto { get; set; }
    }
}
