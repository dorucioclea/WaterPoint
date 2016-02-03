using System.Collections.Generic;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners
{
    public interface IPagedQueryRunner
    {
        PagedPoco<IEnumerable<TOut>> Run<T, TOut>(IQuery<T, TOut> query)
            where T : IQueryParameter
            where TOut : IDataEntity;
    }
}
