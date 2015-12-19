using System.Collections.Generic;
using WaterPoint.Core.Domain;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners
{
    public interface IListPaginatedEntitiesRunner<T>
    {
        PaginatedPoco<IEnumerable<T>> Run(IQuery query);
    }
}
