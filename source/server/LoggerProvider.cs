using Microsoft.Extensions.Logging;

namespace FQ.Server
{
    public class LoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new CustomLogger(categoryName);
        }

        public void Dispose()
        {

        }
    }
}