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
        TOutput Process(TParthInput path, TQueryIntput request);
    }

    public interface ICreateRequestProcessor<in TPathInput, in TInput, out TOutput>
        where TPathInput : IUriPathRequest
        where TInput: IPayload
    {
        TOutput Process(TPathInput pathInput, TInput input);
    }

    public interface IPayload
    {
    }
}
