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

    #region Mensajes para los cuerpos y asuntos de mails ->
    //Recordar siempre el tag <img> sera sustituido al crear el mail en MensajeriaService. Dejarlo donde se quiera sustituir la imagen del logo.
    //De tal manera de que cuando obtenga el cid para el elemento que se quiere incrustar, el mismo sea sustituido.
    //Porque los correos de Mime los crea la clase anteriormente mencionada y el cid lo genera Mime para los HTML de los correos.

    public class NotificacionesRegistro
    {
        public static string AsuntoRegistro = "Registro Exitoso - AgendateApp";

        public static string ObtenerCuerpoRegistro(string nombreUsuario)
        {
            return $@"
                <html>
                  <body>
                    <p>¡Hola {nombreUsuario}!</p>
                    <p>Gracias por registrarte en AgendateApp</p>
                    <p>Esperamos que tu experiencia sea grata en la aplicación</p>
                    <p></p>
                    <p>Atte.</p>
                    <p></p>
                    <p> -> El equipo de Sending Fruits <- </p>
                    <img>
                  </body>
                </html>";
        }
    }

    public class NotificacionesReserva
    {
        public static string AsuntoReservaExitosa = "Nueva reserva registrada - AgendateApp";

        public static string ObtenerCuerpoReservaExitosa(string nombreUsuario, string nombreEmpresa, string nombreServicio)
        {
            return $@"
                <html>
                  <body>
                    <p>¡Hola {nombreUsuario}!</p>
                    <p>Gracias por registrarte en AgendateApp</p>
                    <p>Esperamos que tu experiencia sea grata en la aplicación</p>
                    <p></p>
                    <p>Atte.</p>
                    <p></p>
                    <p> -> El equipo de Sending Fruits <- </p>
                    <img>
                  </body>
                </html>
                ";
        }
    }

    #endregion
}