using System;

namespace LogModule.Loggers
{
    public interface ILogger
    {
        void Error(object message);
        void Debug(object message);
        void Info(object message);

        void AddActionBefore(LogType logType, Action handler);
        void RemoveActionBefore(LogType logType, Action handler);
        void AddActionAfter(LogType logType, Action handler);
        void RemoveActionAfter(LogType logType, Action handler);
        void ClearAllActions(LogType logType);
    }
}