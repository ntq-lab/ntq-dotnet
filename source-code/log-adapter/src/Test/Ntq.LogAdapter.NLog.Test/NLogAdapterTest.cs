using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ntq.LogAdapter.Core;

namespace Ntq.LogAdapter.NLog
{
    [TestClass]
    public class NLogAdapterTest
    {
        [TestMethod]
        public void NLogAdapter_Log_Test()
        {
            ILog logger = new NLogAdapter("Test");
            logger.Debug("Hello {0}", "WORLD");
        }

        [TestMethod]
        public void NLogAdapter_Log_With_Exception_Test()
        {
            //ILog logger = new NLogAdapter();
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
