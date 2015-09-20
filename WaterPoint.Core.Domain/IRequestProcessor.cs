using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain
{
    public interface IRequestProcessor<in TInput, out TOutput>
    {
        TOutput GetResult(TInput request);
    }
}
