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
    public class NotificacionesService
    {
        private readonly INotificaciones _NotiRepo;
        private readonly IMapper _Mapper;
        private readonly APIRespuestas _respuestas;
        private readonly MailConfig _mailConfig;

        public NotificacionesService(INotificaciones notiRepo, IMapper mapper, APIRespuestas respuestas, IOptions<MailConfig> mailConfig)
        {
            _NotiRepo = notiRepo;
            _Mapper = mapper;
            _respuestas = respuestas;
            _mailConfig = mailConfig.Value;
        }

        public async Task<APIRespuestas> CreateMail(Models.NotificacionDTO Noti)
        {

            try
            {
                //Armamos el mensaje Notificacion
                MimeMessage mMessage = new MimeMessage();
                mMessage.From.Add(new MailboxAddress("AgendateApp", _mailConfig.GmailUser));
                mMessage.To.Add(new MailboxAddress("Destino", Noti.correoDestinatario));
                mMessage.Subject = Noti.asunto;

                // BodyBuilder CuerpoMensaje = new BodyBuilder();
                // CuerpoMensaje.TextBody = Noti.cuerpo;

                // mMessage.Body = CuerpoMensaje.ToMessageBody();
                mMessage.Body = new TextPart("html") { Text = Noti.cuerpo };
                //enviamos el mail 
                /* using (var client = new SmtpClient())
                 {
                     await client.ConnectAsync(_mailConfig.Servidor);
                     await client.AuthenticateAsync(_mailConfig.GmailUser, _mailConfig.GmailPassword);
                     await client.SendAsync(mMessage);
                     await client.DisconnectAsync(true);
                 }*/
                SmtpClient ClienteSmtp = new SmtpClient();
                ClienteSmtp.CheckCertificateRevocation = false;
                ClienteSmtp.Connect(_mailConfig.Servidor, _mailConfig.Puerto, MailKit.Security.SecureSocketOptions.StartTls);
                ClienteSmtp.Authenticate(_mailConfig.GmailUser, _mailConfig.GmailPassword);
                ClienteSmtp.Send(mMessage);
                //desconectamos el servidor 
                ClienteSmtp.Disconnect(true);

                Notificacion N = _Mapper.Map<Notificacion>(Noti);
                //Persisto en la  base 
                await _NotiRepo.Crear(N);
                _respuestas.codigo = 0;
                return (_respuestas);


            }
            catch (Exception)
            {
                _respuestas.codigo = 10002;
                return (_respuestas);

            }
        }
    }
}