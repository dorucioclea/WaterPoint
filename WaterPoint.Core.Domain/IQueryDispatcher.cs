using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain
{
    public interface IQueryDispatcher<in TI, out TO>
        where TI : IQuery
    {
        TO Dispatch(TI query);
    }
}
