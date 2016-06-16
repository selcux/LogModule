using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using LogModule.Loggers.TraceLogger.Writers;
using LogModule.LogTypes;

namespace LogModule.Loggers.TraceLogger
{
    public class TraceLogger : AbstractLogger
    {
        private readonly ErrorLogType errorLog;
        private readonly DebugLogType debugLog;
        private readonly InfoLogType infoLog;

        private readonly Dictionary<LogType, AbstractLogType> logTypeTable;

        public TraceLogger()
        {
            ConsoleTraceListener consoleTraceListener = new ConsoleTraceListener();
            Trace.Listeners.Add(consoleTraceListener);

            errorLog = new ErrorLogType(new ErrorTraceWriter());
            debugLog = new DebugLogType(new DebugTraceWriter());
            infoLog = new InfoLogType(new InfoTraceWriter());

            logTypeTable = new Dictionary<LogType, AbstractLogType>
            {
                {LogType.Error, errorLog},
                {LogType.Debug, debugLog},
                {LogType.Info, infoLog}
            };
        }

        public override void Error(object message)
        {
            Log(errorLog, message);
        }

        public override void Debug(object message)
        {
            Log(debugLog, message);
        }

        public override void Info(object message)
        {
            Log(infoLog, message);
        }

        public override void AddActionBefore(LogType logType, Action handler)
        {
            foreach (var typePair in logTypeTable)
            {
                if ((logType & typePair.Key) == typePair.Key)
                {
                    typePair.Value.BeginExecute += handler;
                }
            }
        }

        public override void RemoveActionBefore(LogType logType, Action handler)
        {
            foreach (var typePair in logTypeTable)
            {
                if ((logType & typePair.Key) == typePair.Key)
                {
                    typePair.Value.BeginExecute -= handler;
                }
            }
        }

        public override void AddActionAfter(LogType logType, Action handler)
        {
            foreach (var typePair in logTypeTable)
            {
                if ((logType & typePair.Key) == typePair.Key)
                {
                    typePair.Value.EndExecute += handler;
                }
            }
        }

        public override void RemoveActionAfter(LogType logType, Action handler)
        {
            foreach (var typePair in logTypeTable)
            {
                if ((logType & typePair.Key) == typePair.Key)
                {
                    typePair.Value.EndExecute -= handler;
                }
            }
        }

        public override void ClearAllActions(LogType logType)
        {
            foreach (var typePair in logTypeTable)
            {
                if ((logType & typePair.Key) == typePair.Key)
                {
                    typePair.Value.BeginExecute = null;
                    typePair.Value.EndExecute = null;
                }
            }
        }

        private void Log(AbstractLogType logType, object message)
        {
            logType.Execute($"{GetCallerMethodName()} => {message}");
        }
    }
}