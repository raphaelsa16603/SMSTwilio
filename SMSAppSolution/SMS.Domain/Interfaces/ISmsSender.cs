using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Interfaces
{
    public interface ISmsSender
    {
        void SendSMS(SMSMessage message);
        void CollectReceivedMessages();
    }
}

