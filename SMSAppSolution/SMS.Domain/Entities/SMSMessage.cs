using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class SMSMessage
    {
        public string ToPhoneNumber { get; private set; }
        public string Message { get; private set; }

        public SMSMessage(string toPhoneNumber, string message)
        {
            ToPhoneNumber = toPhoneNumber;
            Message = message;
        }
    }
}

