using System.Collections.Generic;

using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Domain.Db
{
    public interface IQuery<in T, out TOut>
        where T : IQueryParameter
        where TOut : IDataEntity
    {
        void BuildQuery(T parameter);
        string Query { get; }
        object Parameters { get; }
        bool IsStoredProcedure { get; }
    }

    public interface IQueryRunner
    {
        TOut Run<T, TOut>(IQuery<T> query) where TOut : IDataEntity where T : IQueryParameter;
    }

    public interface IQueryListRunner
    {
        IEnumerable<TOut> Run<T, TOut>(IQuery<T> query)
            where T : IQueryParameter
            where TOut : IDataEntity;
    }
}
