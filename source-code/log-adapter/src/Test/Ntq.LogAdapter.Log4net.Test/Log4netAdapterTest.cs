using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ntq.LogAdapter.Core;

namespace Ntq.LogAdapter.Log4net
{
    [TestClass]
    public class Log4netAdapterTest
    {
        [TestMethod]
        public void Log4netAdapter_Log_Test()
        {
            ILog logger = new Log4netAdapter("Test");
            logger.Debug("Hello {0}", "WORLD");
        }

        [TestMethod]
        public void Log4netAdapter_Log_With_Exception_Test()
        {
            ILog logger = new LogFactory().GetLogger();
            try
            {
                int a = 0;
                int b = 5 / a;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Hello {0}", "WORLD");
            }
        }
    }
}
