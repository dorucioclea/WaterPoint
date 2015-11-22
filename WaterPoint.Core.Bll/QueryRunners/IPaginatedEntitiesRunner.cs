using System.Collections.Generic;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners
{
    public interface IPaginatedEntitiesRunner<T>
    {
        PaginatedPoco<IEnumerable<T>> Run(IQuery query);
    }
}
