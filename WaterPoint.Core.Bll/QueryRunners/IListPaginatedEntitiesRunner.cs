using System.Collections.Generic;
using WaterPoint.Core.Domain;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners
{
    public interface IListPaginatedEntitiesRunner<T, TOut> :
        IQueryRunner<T, PaginatedPoco<IEnumerable<TOut>>> where T : IQueryParameter
    {
    }
}
