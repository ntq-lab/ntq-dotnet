using System;
using System.Collections.Generic;
using NLog;

namespace Ntq.LogAdapter.NLog
{
    public class NLogAdapter : Core.LogAdapterBase
    {
        private static readonly Dictionary<Core.LogLevel, LogLevel> LogLevel2NLogLevel = new Dictionary<Core.LogLevel, LogLevel>()
        {
            { Core.LogLevel.Debug, LogLevel.Debug },
            { Core.LogLevel.Info, LogLevel.Info },
            { Core.LogLevel.Warning, LogLevel.Warn },
            { Core.LogLevel.Error, LogLevel.Error },
            { Core.LogLevel.Fatal, LogLevel.Fatal },
        };
        private static readonly Type CurrentType = typeof(NLogAdapter);

        private readonly ILogger _nLogger;

        public NLogAdapter()
            : base()
        {
            this._nLogger = LogManager.GetCurrentClassLogger(GetCallerInfo().Type);
        }

        public NLogAdapter(string name)
            : base(name)
        {
            this._nLogger = LogManager.GetLogger(name);
        }

        public override void Log(Core.LogLevel logLevel, string format, params object[] args)
        {
            LogEventInfo lvi = CreateLogEventInfo(logLevel, null, format, args);
            this._nLogger.Log(CurrentType, lvi);
        }

        public override void Log(Core.LogLevel logLevel, Exception exception, string format, params object[] args)
        {
            LogEventInfo lvi = CreateLogEventInfo(logLevel, exception, format, args);
            this._nLogger.Log(CurrentType, lvi);
        }

        private LogEventInfo CreateLogEventInfo(Core.LogLevel logLevel, Exception exception, string format, params object[] args)
        {
            LogLevel nLogLevel = LogLevel2NLogLevel.ContainsKey(logLevel) ? LogLevel2NLogLevel[logLevel] : LogLevel2NLogLevel[Core.LogLevel.Info];
            LogEventInfo lvi = new LogEventInfo(nLogLevel, this._nLogger.Name, string.Format(format, args))
            {
                Exception = exception
            };

            return lvi;
        }
    }
}
