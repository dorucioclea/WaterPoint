using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Requests;

namespace WaterPoint.Core.Domain
{
    public interface IRequestProcessor<in TParthInput, in TQueryIntput, out TOutput>
        where TParthInput : IUriPathRequest
        where TQueryIntput : IUriQueryRequest

    {
        TOutput Process(TParthInput path, TQueryIntput query);
    }
}
