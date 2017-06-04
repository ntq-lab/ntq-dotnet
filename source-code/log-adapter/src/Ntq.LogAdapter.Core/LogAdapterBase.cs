using System;
using System.Diagnostics;

namespace Ntq.LogAdapter.Core
{
    public abstract class LogAdapterBase : ILog
    {
        protected class CallerInfo
        {
            public Type Type;
            public string FileName;
            public string ClassName;
            public string MethodName;
            public int LineOfCode;
        }
        protected static readonly Type ILogType = typeof(ILog);
        protected static readonly Type CurrentType = typeof(LogAdapterBase);

        public string Name { get; set; }

        protected LogAdapterBase()
        {

        }

        protected LogAdapterBase(string name)
        {
            this.Name = name;
        }

        protected static CallerInfo GetCallerInfo()
        {
            StackFrame sf = null;
            foreach (StackFrame f in new StackTrace(true).GetFrames())
            {
                if (!ILogType.IsAssignableFrom(f.GetMethod().DeclaringType))
                {
                    sf = f;
                    break;
                }
            }

            return new CallerInfo()
            {
                Type = sf.GetMethod().DeclaringType,
                //FileName = new System.IO.FileInfo(sf.GetFileName()).Name,
                ClassName = sf.GetMethod().DeclaringType.Name,
                MethodName = sf.GetMethod().Name,
                LineOfCode = sf.GetFileLineNumber()
            };
        }

        public abstract void Log(LogLevel logLevel, string format, params object[] args);
        public abstract void Log(LogLevel logLevel, Exception exception, string format, params object[] args);

        public virtual void Debug(string format, params object[] args)
        {
            Log(LogLevel.Debug, format, args);
        }

        public virtual void Info(string format, params object[] args)
        {
            Log(LogLevel.Info, format, args);
        }

        public virtual void Warn(string format, params object[] args)
        {
            Log(LogLevel.Warning, format, args);
        }

        public virtual void Warn(Exception exception, string format, params object[] args)
        {
            Log(LogLevel.Warning, exception, format, args);
        }

        public virtual void Error(string format, params object[] args)
        {
            Log(LogLevel.Error, format, args);
        }

        public virtual void Error(Exception exception, string format, params object[] args)
        {
            Log(LogLevel.Error, exception, format, args);
        }

        public virtual void Fatal(string format, params object[] args)
        {
            Log(LogLevel.Fatal, format, args);
        }

        public virtual void Fatal(Exception exception, string format, params object[] args)
        {
            Log(LogLevel.Fatal, exception, format, args);
        }
    }
}
