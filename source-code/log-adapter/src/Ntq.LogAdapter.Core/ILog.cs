using System;

namespace Ntq.LogAdapter.Core
{
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error,
        Fatal
    }

    public interface ILog
    {
        string Name { get; set; }

        void Log(LogLevel logLevel, string format, params object[] args);
        void Log(LogLevel logLevel, Exception exception, string format, params object[] args);
        void Debug(string format, params object[] args);
        void Info(string format, params object[] args);
        void Warn(string format, params object[] args);
        void Warn(Exception exception, string format, params object[] args);
        void Error(string format, params object[] args);
        void Error(Exception exception, string format, params object[] args);
        void Fatal(string format, params object[] args);
        void Fatal(Exception exception, string format, params object[] args);
    }
}
