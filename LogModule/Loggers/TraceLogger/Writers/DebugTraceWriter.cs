using System.Diagnostics;

namespace LogModule.Loggers.TraceLogger.Writers
{
    public class DebugTraceWriter : ILogWriter
    {
        public string LogType { get; } = "DEBUG";

        public void Write(object message)
        {
            Trace.WriteLine(message, LogType);
        }
    }
}