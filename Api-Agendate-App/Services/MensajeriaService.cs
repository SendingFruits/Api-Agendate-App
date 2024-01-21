using Api_Agendate_App.Constantes;
using Api_Agendate_App.Utilidades;
using AutoMapper;
using Microsoft.Extensions.Options;
using Repositorio.IRepositorio;
using Logic.Entities;
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Utils;

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
            string directorioBase = AppDomain.CurrentDomain.BaseDirectory;

            // Construye la ruta relativa a la imagen
            string rutaRelativaImagen = Path.Combine("Recursos", "ImagenesCorreo", "Logo App.png");

            // Combina la ruta relativa con el directorio base para obtener la ruta completa
            string rutaCompletaImagen = Path.Combine(directorioBase, rutaRelativaImagen);

            return rutaCompletaImagen;
        }

        private string SustituirTagImg(string cid, ref string cuerpoCorreo)
        {
            return cuerpoCorreo.Replace("<img>", $"<img src=\"\"cid:{cid}\"\" alt=\"\"Logo de AgendateApp\"\">");
        }
    }
}