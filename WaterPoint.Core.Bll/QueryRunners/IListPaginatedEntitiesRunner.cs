using System.Collections.Generic;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners
{
    public interface IListPaginatedEntitiesRunner<T>
    {
        PaginatedPoco<IEnumerable<T>> Run(IQuery query);
    }
}
