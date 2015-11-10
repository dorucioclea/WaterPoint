using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Requests;

namespace WaterPoint.Core.Domain
{
    public interface IRequestProcessor<in TPathInput, in TQueryIntput, out TOutput>
        where TPathInput : IUriPathRequest
        where TQueryIntput : IUriQueryRequest

    {
        TOutput Process(TPathInput path, TQueryIntput request);
    }

    public interface IRequestProcessor<in TPathInput, out TOutput>
        where TPathInput : IUriPathRequest
    {
        TOutput Process(TPathInput path);
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
