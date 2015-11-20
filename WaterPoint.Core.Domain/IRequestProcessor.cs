using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaterPoint.Core.Domain.RequestDtos;

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
    {
        TOutput Process(TPathInput pathInput, TInput input);
    }
    
    public interface IUpdateRequestProcessor<in TPathInput, in TInput, out TOutput>
        where TPathInput : IUriPathRequest
    {
        TOutput Process(TPathInput pathInput, TInput input);
    }
}
