using System.Collections.Generic;
using System.Web.Http.OData;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain
{
    public interface IRequest
    {
    }

    public interface ICreateRequest<T> : IRequest
        where T : IPayload
    {
        T Payload { get; set; }
    }

    public interface IUpdateRequest<T> : IRequest
        where T : class, IPayload
    {
        Delta<T> Payload { get; set; }
    }

    public interface IPayload
    {

    }

    public interface IRequestProcessor<in TInput, out TOutput>
        where TInput : IRequest
        where TOutput : IContract
    {
        TOutput Process(TInput input);
    }

    public interface ISimplePagedProcessor<in TInput, TOutput>
        where TInput : IRequest
        where TOutput : IContract
    {
        SimplePagedResult<TOutput> Process(TInput input);
    }

    public interface IPagedProcessor<in TInput, TOutput>
        where TInput : IRequest
        where TOutput : IContract
    {
        PagedResult<TOutput> Process(TInput input);
    }

    public interface IListProcessor<in TInput, out TOutput>
        where TInput : IRequest
        where TOutput : IContract
    {
        IEnumerable<TOutput> Process(TInput input);
    }

    public interface IWriteRequestProcessor<in TInput>
        where TInput : IRequest
    {
        CommandResult Process(TInput input);
    }
}
