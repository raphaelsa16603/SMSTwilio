using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Interfaces
{
    public interface ILogger
    {
        void LogInfo(string message, string logType);
        void LogError(string message, Exception ex);
    }
}

