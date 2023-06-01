namespace Api_Agendate_App.Models
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public string usuario { get; set; }

        public string contraseña { get; set; }

        public string nombreCompleto { get; set; }

        public string correoElectronico { get; set; }

        public string celular { get; set; }
    }
}
