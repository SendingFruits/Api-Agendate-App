namespace Api_Agendate_App.Constantes
{
    public class MailConfig
    {

        public string Servidor { get; }
        public int Puerto { get; }
        public string GmailUser { get; }
        public string GmailPassword { get; }

        public MailConfig()
        {
            Servidor = "smtp.gmail.com";
            Puerto = 587;
            GmailUser = "leeroyjenkins2320@gmail.com";
            GmailPassword = "UnaPassMuyDificil1234%";
        }
    }
}