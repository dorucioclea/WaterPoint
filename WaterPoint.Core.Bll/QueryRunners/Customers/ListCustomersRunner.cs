using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners.Customers
{
    public class ListCustomersRunner : IListEntitiesRunner<PaginatedOrgIdIsProspect, Customer>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public ListCustomersRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public PaginatedPoco<IEnumerable<Customer>> Run(IQuery<PaginatedOrgIdIsProspect> query)
        {
            var rawResults = _dapperDbContext
                .List<Customer, PaginatedPoco>(
                    query.Query,
                    PaginatedPoco.SplitOnColumn,
                    query.Parameters)
                .ToArray();

            if (!rawResults.Any())
                return null;

            var result = new PaginatedPoco<IEnumerable<Customer>>
            {
                TotalCount = rawResults.First().Item2.TotalCount,
                Data = rawResults.Select(i => i.Item1)
            };

            return result;
        }
    }
}
