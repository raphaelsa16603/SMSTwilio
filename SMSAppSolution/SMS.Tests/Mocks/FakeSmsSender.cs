using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Tests.Mocks
{
    public class FakeSmsSender : ISmsSender
    {
        public bool MessageSent { get; private set; } = false;

        public void SendSMS(SMSMessage message)
        {
            // Simula o envio de SMS
            MessageSent = true;
        }

        public void CollectReceivedMessages()
        {
            // Simula a coleta de mensagens recebidas
        }
    }
}

