using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain
{
    public interface IContractConvertor<in TInput, out TOutput>
    {
        TOutput Convert(TInput request);
    }
}
