using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.QueryParameters.Shared;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners.CostItems
{
    public class ListCostItemsRunner: IListEntitiesRunner<PaginatedOrgId, CostItem>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public ListCostItemsRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public PaginatedPoco<IEnumerable<CostItem>> Run(IQuery<PaginatedOrgId> query)
        {
            var rawResults = _dapperDbContext
                .List<CostItem, PaginatedPoco>(
                    query.Query,
                    PaginatedPoco.SplitOnColumn,
                    query.Parameters)
                .ToArray();

            if (!rawResults.Any())
                return null;

            var result = new PaginatedPoco<IEnumerable<CostItem>>
            {
                TotalCount = rawResults.First().Item2.TotalCount,
                Data = rawResults.Select(i => i.Item1)
            };

            return result;
        }
    }

}
