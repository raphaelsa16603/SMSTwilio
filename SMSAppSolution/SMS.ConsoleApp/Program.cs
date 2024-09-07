using System;
using System.IO;
using Newtonsoft.Json;
using SMS.Domain.Entities;
using SMS.Infrastructure.Services;
using System.Globalization;

namespace SMS.ConsoleApp
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando envio de SMS...");

            var configFilePath = "sms_config.json";
            var config = LoadConfig(configFilePath);

            string sStartTime = config.Schedule.StartTime;
            string sEndTime = config.Schedule.EndTime;

            int horaStart = int.Parse(sStartTime.Substring(0, 2));
            int minutoStart = int.Parse(sStartTime.Substring(3, 2));
            int horaEnd = int.Parse(sEndTime.Substring(0, 2));
            int minutoEnd = int.Parse(sEndTime.Substring(3, 2));

            var logger = new FileLogger("LOG");

            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, horaStart, minutoStart, 00);
            var endTime   = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, horaEnd, minutoEnd, 00);

            if (startTime == null || endTime == null)
            {
                Console.WriteLine("Formato de horário inválido na configuração.");
                return;
            }

            var now = DateTime.Now;

            if (now < startTime || now > endTime)
            {
                Console.WriteLine("Fora do horário de envio de SMS configurado.");
                return;
            }

            var smsSender = new TwilioSmsSender(
                config.Twilio.AccountSid,
                config.Twilio.AuthToken,
                config.Twilio.FromPhoneNumber,
                logger
            );

            try
            {
                foreach (var messageConfig in config.Messages)
                {
                    foreach (var text in messageConfig.Texts)
                    {
                        var smsMessage = new SMSMessage(messageConfig.PhoneNumber, text);
                        smsSender.SendSMS(smsMessage);
                    }
                }

                smsSender.CollectReceivedMessages();
            }
            catch (Exception ex)
            {
                logger.LogError("Erro no processo de envio e recebimento de SMS", ex);
            }
        }

        // Função para carregar a configuração do arquivo JSON
        private static dynamic LoadConfig(string configFilePath)
        {
            try
            {
                var json = File.ReadAllText(configFilePath);
                return JsonConvert.DeserializeObject<dynamic>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar o arquivo de configuração.", ex);
            }
        }
    }
}

