using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Ntq.LogAdapter.Core
{
    public class DebugConsoleLogger : LogAdapterBase
    {
        private static readonly Dictionary<LogLevel, string> LogLevel2Str = new Dictionary<LogLevel, string>()
        {
            { LogLevel.Debug, "DBG" },
            { LogLevel.Info, "INF" },
            { LogLevel.Warning, "WRN" },
            { LogLevel.Error, "ERR" },
            { LogLevel.Fatal, "FTL" },
        };

        private static readonly char SeparatorChar = '\t';

        public DebugConsoleLogger()
            : base()
        {

        }

        public DebugConsoleLogger(string name)
            : base(name)
        {

        }

        public override void Log(LogLevel logLevel, string format, params object[] args)
        {
            WriteLog(logLevel, null, format, args);
        }

        public override void Log(LogLevel logLevel, Exception exception, string format, params object[] args)
        {
            WriteLog(logLevel, exception, format, args);
        }

        private static void WriteLog(LogLevel logLevel, Exception exception, string format, params object[] args)
        {
            CallerInfo ci = GetCallerInfo();

            string logLevelStr = LogLevel2Str.ContainsKey(logLevel) ? LogLevel2Str[logLevel] : LogLevel2Str[LogLevel.Info];
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")).Append(SeparatorChar)
                .Append(logLevelStr).Append(SeparatorChar)
                .AppendFormat(format, args).Append(SeparatorChar);

            if (exception != null)
            {
                sb.AppendLine()
                    .Append("StackTrace:").AppendLine()
                    .Append(exception.ToString());
            }

            System.Diagnostics.Debug.WriteLine(sb.ToString());
        }
    }
}
