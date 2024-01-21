using MimeKit;

namespace Api_Agendate_App.Constantes
{
    public class Mensajeria
    {
        #region Configuracion Correo ->
        private static string gmailUser = "leeroyjenkins2320@gmail.com";
        private static string gmailPassword = "pqeeivadwqcwdthx";
        private static string servidor = "smtp.gmail.com";
        private static int puerto = 465;

        public static string GmailUser
        {
            get {return gmailUser; }
        }

        public static string GmailPassword
        {
            get { return gmailPassword; }
        }

        public static string Servidor
        {
            get { return servidor; }
        }

        public static int Puerto
        {
            get { return puerto; }
        }

        #endregion
    }

    public class NotificacionesRegistro
    {
        public static string AsuntoRegistro = "Registro Exitoso - AgendateApp";

        public static string ObtenerCuerpoRegistro(string nombreUsuario)
        {
            return $"Gracias por registrarte en AgendateApp {nombreUsuario}, estamos muy felices de que formes parte de esta comunidad. " +
                    "Aquí podrás encontrar a muchos clientes de tu zona buscando tu Servicio.";
        }
    }

    public class NotificacionesReserva
    {
        public static string AsuntoReservaExitosa = "Nueva reserva registrada - AgendateApp";

        public static string ObtenerCuerpoReservaExitosa(string nombreUsuario, string nombreEmpresa, string nombreServicio, )
        {
            return $"Gracias por registrarte en AgendateApp {nombreUsuario}, estamos muy felices de que formes parte de esta comunidad. " +
                    "Aquí podrás encontrar a muchos clientes de tu zona buscando tu Servicio.";
        }
    }

}