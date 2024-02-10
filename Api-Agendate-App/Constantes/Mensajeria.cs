using Api_Agendate_App.Utilidades;
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
                    <p></p>
                    <p><em>Este es un correo automático. No contestar el mismo.</em></p>
                  </body>
                </html>";
        }
    }

    public class NotificacionesReserva
    {
        public static string ObtenerAsuntoReservaExitosa (string nombreEmpresa)
        {
            return $"Nueva reserva en {nombreEmpresa} - AgendateApp";
        }

        public static string ObtenerCuerpoReservaExitosa(string nombreUsuario, string nombreServicio, DateTime fechaTurno, string nombreEmpresa, string direccionEmpresa, string? celularEmpresa, string? correoEmpresa)
        {
            string Cuerpo =  $@"
                <html>
                  <body>
                    <p>¡Hola {nombreUsuario}!</p>
                    <p>Te informamos que tu reserva para el servicio: {nombreServicio}, de la empresa: {nombreEmpresa} fue registrada correctamente.</p>
                    <p>Recuerda presentarte el día: <b>{UtilidadesParaFechas.DevolverDiaDeSemanaEspanol(fechaTurno)}</b> {fechaTurno.Date.Day} de {UtilidadesParaFechas.DevolverMesEspanol(fechaTurno)} a las {fechaTurno.Hour}:{fechaTurno.Minute} </p>
                    <p>La dirección de donde debes presentarte es: {direccionEmpresa}</p>
                    
                    {(celularEmpresa == null && correoEmpresa == null ? "<p><b>La empresa no proporcionó información de contacto por lo que debes presentarte en la dirección o buscar otro método de contacto</b></p>" :
                    "")}
                    {(celularEmpresa != null || correoEmpresa != null ? "<p><b>Información de contacto de la empresa:</b> $$CorreoEmpresa $$CelularEmpresa</p>" :
                    "")}
                    <p></p>
                    <img>
                    <p></p>
                    <p><em>Este es un correo automático. No contestar el mismo.</em></p>
                  </body>
                </html>
                ";

            if (correoEmpresa != null && celularEmpresa != null)
            {
                Cuerpo = Cuerpo.Replace("$$CorreoEmpresa", correoEmpresa);
                Cuerpo = Cuerpo.Replace("$$CelularEmpresa", " | " + celularEmpresa);
            }
            else
            {
                if (correoEmpresa != null)
                    Cuerpo =Cuerpo.Replace("$$CorreoEmpresa", correoEmpresa);
                else
                    Cuerpo =Cuerpo.Replace("$$CorreoEmpresa", "");

                if (celularEmpresa != null)
                    Cuerpo = Cuerpo.Replace("$$CorreoEmpresa", celularEmpresa);
                else
                    Cuerpo = Cuerpo.Replace("$$CorreoEmpresa", "");
            }

            return Cuerpo;
        }
    
    }

    public class NotificacionesImportantes
    {
        public static string ObtenerAsuntoCambioContrasenia()
        {
            return $"Cambio de contraseña - AgendateApp";
        }

        public static string ObtenerCuerpoModificacionContrasenia(string nombreUsuario)
        {
            return $@"
                <html>
                  <body>
                    <p>¡Hola {nombreUsuario}!</p>
                    <p>Te informamos que tu contraseña fue modificada correctamente.</p>
                    <p>En el caso que no hayas sido tú, debes contactarte inmediatamente con soporte@sendingfruits.com: </p>
                    <p></p>
                    <p>Atte.</p>
                    <p></p>
                    <p> -> El equipo de Sending Fruits <- </p>
                    <img>
                    <p></p>
                    <p><em>Este es un correo automático. No contestar el mismo.</em></p>
                  </body>
                </html>
                ";
        }
    }
    #endregion
}