using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ntq.LogAdapter.Core
{
    [TestClass]
    public class DebugConsoleLoggerTest
    {
        [TestMethod]
        public void DebugConsoleLogger_Log_Test()
        {
            ILog logger = new DebugConsoleLogger("Test");
            logger.Debug("Hello {0}", "WORLD");
        }

        [TestMethod]
        public void DebugConsoleLogger_Log_With_Exception_Test()
        {
            ILog logger = new DebugConsoleLogger("Test");
            Exception ex = new Exception("Dummy exception");

            logger.Error(ex, "Hello {0}", "WORLD");
        }
    }
}
