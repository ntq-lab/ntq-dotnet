using System;
using Ntq.LogAdapter.Core;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            for (LogLevel lv = LogLevel.Debug; lv <= LogLevel.Fatal; lv++)
            {
                WriteLog1(lv, "WriteLog1 at level " + lv.ToString().ToUpper());
            }

            for (LogLevel lv = LogLevel.Debug; lv <= LogLevel.Fatal; lv++)
            {
                Guid guid = Guid.NewGuid();
                WriteLog2(lv, "WriteLog2 at level {0}, generated GUID = {1}", lv.ToString().ToUpper(), guid);
            }

            {
                ILog logger = LogFactory.Default.GetLogger();
                Exception ex = new ArgumentException("Wrong email format", "userEmail",
                                                    new Exception("Dummy inner exception"));
                logger.Warn(ex, "Write log by Warn()");
                logger.Error(ex, "Write log by Error()");
                logger.Fatal(ex, "Write log by Fatal()");
                logger.Log(LogLevel.Fatal, ex, "Write log by Log()");
            }

            Console.ReadKey();
        }

        private static void WriteLog1(LogLevel level, string message)
        {
            ILog logger = LogFactory.Default.GetLogger();
            logger.Log(level, message);
        }

        private static void WriteLog2(LogLevel level, string format, params object[] args)
        {
            ILog logger = new LogFactory().GetLogger();
            logger.Log(level, format, args);
        }
    }
}
