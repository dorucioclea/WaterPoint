using System.Collections.Generic;
using WaterPoint.Core.Domain.Contracts;

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
        where TOutput : IContract
    {
        IEnumerable<TOutput> Process(TInput input);
    }
}
