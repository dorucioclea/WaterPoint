﻿using System.Collections.Generic;
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

    public interface ISimplePaginatedProcessor<in TInput, TOutput>
        where TInput : IRequest
        where TOutput : IContract
    {
        SimplePaginatedResult<TOutput> Process(TInput input);
    }

    public interface IPaginatedProcessor<in TInput, TOutput>
        where TInput : IRequest
        where TOutput : IContract
    {
        PaginatedResult<TOutput> Process(TInput input);
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
