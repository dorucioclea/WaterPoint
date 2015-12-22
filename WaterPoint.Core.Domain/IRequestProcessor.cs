using System.Collections.Generic;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos;

namespace WaterPoint.Core.Domain
{
    public interface IRequest
    {
    }

    public interface IRequestProcessor<in TInput, out TOutput>
        where TInput : IRequest
        where TOutput : IContract
    {
        TOutput Process(TInput input);
    }

    public interface IRequestCollectionProcessor<in TInput, out TOutput>
        where TInput : IRequest
        where TOutput : IEnumerable<IContract>
    {
        TOutput Process(TInput input);
    }
}
