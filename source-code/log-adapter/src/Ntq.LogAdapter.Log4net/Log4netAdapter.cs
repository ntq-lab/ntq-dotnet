using System;
using System.Collections.Generic;
using log4net;
using log4net.Core;

namespace Ntq.LogAdapter.Log4net
{
    public class Log4netAdapter : Core.LogAdapterBase
    {
        private static readonly Dictionary<Core.LogLevel, Level> LogLevel2Log4netLevel = new Dictionary<Core.LogLevel, Level>()
        {
            { Core.LogLevel.Debug, Level.Debug },
            { Core.LogLevel.Info, Level.Info },
            { Core.LogLevel.Warning, Level.Warn },
            { Core.LogLevel.Error, Level.Error },
            { Core.LogLevel.Fatal, Level.Fatal },
        };
        private static readonly Type CurrentType = typeof(Log4netAdapter);

        private readonly ILog _logger;

        public Log4netAdapter()
            : base()
        {
            this._logger = LogManager.GetLogger(GetCallerInfo().Type);
        }

        public Log4netAdapter(string name)
            : base(name)
        {
            this._logger = LogManager.GetLogger(name);
        }

        public override void Log(Core.LogLevel logLevel, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public override void Log(Core.LogLevel logLevel, Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        private LoggingEvent CreateLogEventInfo(Core.LogLevel logLevel, Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
