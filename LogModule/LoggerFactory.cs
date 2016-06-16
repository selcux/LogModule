using System;
using LogModule.Loggers;

namespace LogModule
{
    public class LoggerFactory
    {
        public static T Create<T>() where T : ILogger, new()
        {
            return Activator.CreateInstance<T>();
        }
    }
}