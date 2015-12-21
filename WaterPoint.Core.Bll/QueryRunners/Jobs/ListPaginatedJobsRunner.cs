using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.Bll.QueryRunners.Jobs
{
    public class ListPaginatedJobsRunner : IListPaginatedEntitiesRunner<PaginatedJobsQueryParameter, JobWithCustomerAndStatusPoco>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public ListPaginatedJobsRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public PaginatedPoco<IEnumerable<JobWithCustomerAndStatusPoco>> Run(IQuery<PaginatedJobsQueryParameter> query)
        {
            var rawResults = _dapperDbContext
                .List<JobWithCustomerAndStatusPoco, PaginatedPoco>(
                    query.Query,
                    PaginatedPoco.SplitOnColumn,
                    query.Parameters)
                .ToArray();

            if (!rawResults.Any())
                return null;

            var result = new PaginatedPoco<IEnumerable<JobWithCustomerAndStatusPoco>>
            {
                TotalCount = rawResults.First().Item2.TotalCount,
                Data = rawResults.Select(i => i.Item1)
            };

            return result;
        }
    }
}
