namespace Api_Agendate_App.Models
{
    public class MClientes : MUsuarios
    {
        public string documento { get; set; }

        public byte[] foto { get; set; }
    }
}
