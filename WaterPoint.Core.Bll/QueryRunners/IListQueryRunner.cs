using System.Collections.Generic;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners
{
    public interface IListQueryRunner<T, TOut> : IQueryRunner<T, PaginatedPoco<IEnumerable<TOut>>>
        where T : IQueryParameter
        where TOut : new()
    {
    }
}
