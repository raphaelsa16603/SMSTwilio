using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Interfaces;
using System;
using System.IO;

namespace SMS.Infrastructure.Services
{
    public class FileLogger : ILogger
    {
        private readonly string _baseLogPath = "LOG";


        public FileLogger(string baseLogPath)
        {
            _baseLogPath = baseLogPath;
        }

        public void LogInfo(string message, string logType)
        {
            try
            {
                string logPath = GetLogFilePath(logType);
                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    sw.WriteLine($"{DateTime.Now:G} INFO: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar log de informação: {ex.Message}");
            }
        }

        public void LogError(string message, Exception ex)
        {
            try
            {
                string logPath = GetLogFilePath("ERROS", true);
                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    sw.WriteLine($"{DateTime.Now:G} ERROR: {message} - Exception: {ex.Message}");
                    if (ex.StackTrace != null)
                    {
                        sw.WriteLine($"StackTrace: {ex.StackTrace}");
                    }
                }
            }
            catch (Exception logEx)
            {
                Console.WriteLine($"Erro ao gravar log de erro: {logEx.Message}");
            }
        }

        private string GetLogFilePath(string logType, bool isError = false)
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.ToString("yyyy-MM");
            string day = DateTime.Now.ToString("yyyy-MM-dd");
            string hour = DateTime.Now.ToString("HH");

            string folderPath = Path.Combine(_baseLogPath, year, month, day, logType);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string logFileName;
            if (isError)
            {
                string minute = DateTime.Now.ToString("mm");
                logFileName = $"{hour}_{minute}_ERROS.log";
            }
            else
            {
                logFileName = $"{hour}_LOG.log";
            }

            return Path.Combine(folderPath, logFileName);
        }
    }
}

