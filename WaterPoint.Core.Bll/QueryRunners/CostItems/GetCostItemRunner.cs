using System.Linq;
using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.QueryRunners.CostItems
{
    public class GetCostItemRunner : IQueryRunner<GetCostItem, CostItem>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetCostItemRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public CostItem Run(IQuery<GetCostItem> query)
        {
            var costItem = _dapperDbContext
                .List<CostItem>(query.Query, query.Parameters)
                .SingleOrDefault();

            return costItem;
        }
    }
}
