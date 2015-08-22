using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Repository
{
    public class TransactionExecuter:IDisposable
    {
        ~TransactionExecuter()
        {
            Dispose();
        }

        public void Dispose()
        {
        }
    }
}
