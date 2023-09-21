using Api_Agendate_App.Constantes;
using Api_Agendate_App.Utilidades;
using AutoMapper;
using Microsoft.Extensions.Options;
using Repositorio.IRepositorio;
using Logic.Entities;
using MimeKit;
using MailKit.Net.Smtp;

namespace Api_Agendate_App.Services
{
    public class MensajeriaService
    {
        private readonly INotificaciones _NotiRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;
        private readonly Mensajeria _mailConfig;

        private readonly string Servidor = "smtp.gmail.com";
        private readonly int Puerto = 587;

        public MensajeriaService(INotificaciones notiRepo, IMapper mapper, APIRespuestas respuestas, IOptions<Mensajeria> mailConfig)
        {
            _NotiRepo = notiRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
            _mailConfig = mailConfig.Value;
        }

        public async Task<APIRespuestas> CreateMail(string correoDestinatario)
        {
            try
            {
                Mensajeria mensajeria = new Mensajeria();
                //Armamos el mensaje Notificacion
                MimeMessage mMessage = new MimeMessage();
                mMessage.From.Add(new MailboxAddress("AgendateApp", Mensajeria.GmailUser));
                mMessage.To.Add(new MailboxAddress("Destino", correoDestinatario));
                mMessage.Subject = Mensajes.AsuntoRegistro;

                // BodyBuilder CuerpoMensaje = new BodyBuilder();
                // CuerpoMensaje.TextBody = Noti.cuerpo;

                // mMessage.Body = CuerpoMensaje.ToMessageBody();
                mMessage.Body = new TextPart("html") { Text = Mensajes.CuerpoRegistro };
                //enviamos el mail 
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(Servidor,Puerto,true);
                    await client.AuthenticateAsync(Mensajeria.GmailUser, Mensajeria.GmailPassword);
                    await client.SendAsync(mMessage);
                    await client.DisconnectAsync(true);
                }
                //SmtpClient ClienteSmtp = new SmtpClient();
                //ClienteSmtp.CheckCertificateRevocation = false;
                //ClienteSmtp.Connect(_mailConfig.Servidor, _mailConfig.Puerto, MailKit.Security.SecureSocketOptions.StartTls);
                //ClienteSmtp.Authenticate(_mailConfig.GmailUser, _mailConfig.GmailPassword);
                //ClienteSmtp.Send(mMessage);
                //desconectamos el servidor 
                //ClienteSmtp.Disconnect(true);

                return (_respuestas);

            }
            catch (Exception)
            {
                _respuestas.codigo = 1002;
                return (_respuestas);
            }
        }
    }
}