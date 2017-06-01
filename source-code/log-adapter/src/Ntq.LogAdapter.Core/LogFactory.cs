using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntq.LogAdapter.Core
{
    public class LogFactory
    {
        public virtual ILog GetLogger()
        {
            throw new NotImplementedException();
        }

        public virtual ILog GetLogger(string name)
        {
            throw new NotImplementedException();
        }
    }
}
