using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SMS.Infrastructure.Services
{
    public class TwilioSmsSender : ISmsSender
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromPhoneNumber;
        private readonly ILogger _logger;

        public TwilioSmsSender(string accountSid, string authToken, string fromPhoneNumber, ILogger logger)
        {
            _accountSid = accountSid;
            _authToken = authToken;
            _fromPhoneNumber = fromPhoneNumber;
            _logger = logger;
            TwilioClient.Init(_accountSid, _authToken);
        }

        public void SendSMS(SMSMessage message)
        {
            try
            {
                var msg = MessageResource.Create(
                    body: message.Message,
                    from: new PhoneNumber(_fromPhoneNumber),
                    to: new PhoneNumber(message.ToPhoneNumber)
                );

                _logger.LogInfo($"SMS enviado para {message.ToPhoneNumber}. SID: {msg.Sid}, Mensagem: {message.Message}", "ENVIOS");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao enviar SMS para {message.ToPhoneNumber}", ex);
                throw;
            }
        }

        public void CollectReceivedMessages()
        {
            try
            {
                var messages = MessageResource.Read(to: new PhoneNumber(_fromPhoneNumber), dateSent: DateTime.Now.Date);

                foreach (var message in messages)
                {
                    var logMessage = $"Data: {message.DateSent}, De: {message.From}, Texto: {message.Body}";
                    _logger.LogInfo(logMessage, "RETORNOS");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao coletar mensagens recebidas", ex);
            }
        }
    }
}
