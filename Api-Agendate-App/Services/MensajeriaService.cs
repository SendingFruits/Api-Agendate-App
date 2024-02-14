using Api_Agendate_App.Constantes;
using Api_Agendate_App.Utilidades;
using AutoMapper;
using Microsoft.Extensions.Options;
using Repositorio.IRepositorio;
using Logic.Entities;
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Utils;
using Microsoft.IdentityModel.Tokens;

namespace Api_Agendate_App.Services
{
    public class MensajeriaService
    {
        private readonly INotificaciones _NotiRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;

        
        public MensajeriaService(INotificaciones notiRepo, IMapper mapper, APIRespuestas respuestas, IOptions<Mensajeria> mailConfig)
        {
            _NotiRepo = notiRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
        }

        public async Task<APIRespuestas> CreateMail(string correoDestinatario, string asuntoCorreo, string cuerpoCorreo)
        {
            try
            {
                //Datos Basicos
                MimeMessage correoMime = new MimeMessage();
                var bodyBuilder = new BodyBuilder();
                correoMime.From.Add(new MailboxAddress("AgendateApp", Mensajeria.GmailUser));
                correoMime.To.Add(new MailboxAddress("Destino", correoDestinatario));
                correoMime.Subject = asuntoCorreo;

                //Insercion imagen del logo AgendateApp
                var imagenLogoAgendateApp = bodyBuilder.LinkedResources.Add(ObtenerRutaImagenApp());
                var cid = MimeUtils.GenerateMessageId();
                imagenLogoAgendateApp.ContentId = cid;
                SustituirTagImg(cid, ref cuerpoCorreo);


                bodyBuilder.HtmlBody = cuerpoCorreo;
                correoMime.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(Mensajeria.Servidor, Mensajeria.Puerto, true);
                    await client.AuthenticateAsync(Mensajeria.GmailUser, Mensajeria.GmailPassword);
                    await client.SendAsync(correoMime);
                    await client.DisconnectAsync(true);
                }

                Notificaciones notificacionNueva = new Notificaciones();
                notificacionNueva.fechaEnvio = DateTime.Now;
                notificacionNueva.correoDestinatario = correoDestinatario;
                notificacionNueva.asunto = asuntoCorreo;
                notificacionNueva.cuerpo = cuerpoCorreo;
                notificacionNueva.IdEmpresa = null;
                _NotiRepo.Crear(notificacionNueva);

                return (_respuestas);

            }
            catch (Exception)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInesperadoEnviarMensaje;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return (_respuestas);
            }
        }


        public async Task<APIRespuestas> EnviarEmailPromocion(Dictionary<string,string> destinatarios, string asuntoCorreo, string cuerpoCorreo)
        {
            try
            {
                //Datos Basicos
                MimeMessage correoMime = new MimeMessage();
                var bodyBuilder = new BodyBuilder();
                correoMime.From.Add(new MailboxAddress("AgendateApp", Mensajeria.GmailUser));
                string correosDestinatarios = "";
                //Siempre va a venir como key el nombre del cliente y como valor el correo electronico.
                foreach (var kvp in destinatarios)
                {
                    //Agrega correo al mime que crea el correo a enviar
                    correoMime.To.Add(new MailboxAddress(kvp.Key, kvp.Value));

                    //Agrega correo al string que logueara la notificacion en la bd
                    if (!correosDestinatarios.IsNullOrEmpty())
                        correosDestinatarios = string.Concat(correosDestinatarios, ',', kvp.Value);
                    else
                        correosDestinatarios = kvp.Value;
                }
                
                correoMime.Subject = asuntoCorreo;

                //Insercion imagen del logo AgendateApp
                var imagenLogoAgendateApp = bodyBuilder.LinkedResources.Add(ObtenerRutaImagenApp());
                var cid = MimeUtils.GenerateMessageId();
                imagenLogoAgendateApp.ContentId = cid;
                SustituirTagImg(cid, ref cuerpoCorreo);


                bodyBuilder.HtmlBody = cuerpoCorreo;
                correoMime.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(Mensajeria.Servidor, Mensajeria.Puerto, true);
                    await client.AuthenticateAsync(Mensajeria.GmailUser, Mensajeria.GmailPassword);
                    await client.SendAsync(correoMime);
                    await client.DisconnectAsync(true);
                }

                Notificaciones notificacionNueva = new Notificaciones();
                notificacionNueva.fechaEnvio = DateTime.Now;
                notificacionNueva.correoDestinatario = correosDestinatarios;
                notificacionNueva.asunto = asuntoCorreo;
                notificacionNueva.cuerpo = cuerpoCorreo;
                notificacionNueva.IdEmpresa = null;
                _NotiRepo.Crear(notificacionNueva);

                return (_respuestas);

            }
            catch (Exception)
            {
                _respuestas.codigo = ConstantesDeErrores.ErrorInesperadoEnviarMensaje;
                _respuestas.mensaje = ConstantesDeErrores.DevolverMensaje(_respuestas.codigo);
                return (_respuestas);
            }
        }
        private string ObtenerRutaImagenApp ()
        {
            // Obtén la ruta del directorio de ejecución de la aplicación
            string directorioBase = Environment.CurrentDirectory;

            // Construye la ruta relativa a la imagen
            string rutaRelativaImagen = Path.Combine("Recursos", "ImagenesCorreo", "Logo App.png");

            // Combina la ruta relativa con el directorio base para obtener la ruta completa
            string rutaCompletaImagen = Path.Combine(directorioBase, rutaRelativaImagen);

            return rutaCompletaImagen;
        }

        private void SustituirTagImg(string cid, ref string cuerpoCorreo)
        {
            cuerpoCorreo = cuerpoCorreo.Replace("<img>", $"<img src=\"cid:{cid}\" alt=\"Logo de AgendateApp \" >");
        }
    }
}