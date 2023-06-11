namespace Api_Agendate_App.DTOs
{
    public class ClienteDTO : UsuarioDTO
    {
        public string Documento { get; set; }

        public byte[] Foto { get; set; }
    }
}
