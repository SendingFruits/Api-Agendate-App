using MimeKit;

namespace Api_Agendate_App.Constantes
{
    public class Mensajeria
    {
        private static string gmailUser = "leeroyjenkins2320@gmail.com";
        private static string gmailPassword = "UnaPassMuyDificil1234%";

        public static string GmailUser
        {
            get {return gmailUser; }
        }

        public static string GmailPassword
        {
            get { return gmailPassword; }
        }
    }

    public static class Mensajes
    {
        public static string CuerpoRegistro = "Gracias por registrarte en AgendateApp , estamos muy felices de que formes parte de esta comunidad. " + "br/" +
                    "Aquí podras encontrar a muchos clientes  de tú zona buscando tu Servicio. ";

        public static string AsuntoRegistro = "Registro Exitoso - AgendateApp";
    }
}