using System.Collections.Generic;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners
{
    public interface IPagedQueryRunner<T, TOut> : IQueryRunner<T, PagedPoco<IEnumerable<TOut>>>
        where T : IQueryParameter
        where TOut : IDataEntity, new()
    {
    }
}
