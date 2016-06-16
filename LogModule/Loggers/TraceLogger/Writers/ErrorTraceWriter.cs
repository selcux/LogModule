using System.Diagnostics;

namespace LogModule.Loggers.TraceLogger.Writers
{
    public class ErrorTraceWriter : ILogWriter
    {
        public string LogType { get; } = "ERROR";

        public void Write(object message)
        {
            Trace.WriteLine(message, LogType);
        }
    }
}