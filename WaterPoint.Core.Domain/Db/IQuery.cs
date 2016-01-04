﻿using System.Collections.Generic;

using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Domain.Db
{
    public interface IQuery<in T> where T : IQueryParameter
    {
        void BuildQuery(T parameter);
        string Query { get; }
        object Parameters { get; }
        bool IsStoredProcedure { get; }
    }

    public interface IQueryParameter
    {
    }

    public interface IPagedQueryParameter : IQueryParameter
    {
        int Offset { get; set; }
        int PageSize { get; set; }
        string Sort { get; set; }
        bool IsDesc { get; set; }
        string SearchTerm { get; set; }
    }

    public interface ISimplePagedQueryParameter : IQueryParameter
    {
        int Offset { get; set; }
        int PageSize { get; set; }
    }

    public interface IQueryRunner<T, out TOut>
        where T : IQueryParameter
        where TOut : IDataEntity
    {
        TOut Run(IQuery<T> query);
    }

    public interface IQueryListRunner<T, out TOut>
        where T : IQueryParameter
        where TOut : IDataEntity
    {
        IEnumerable<TOut> Run(IQuery<T> query);
    }
}
