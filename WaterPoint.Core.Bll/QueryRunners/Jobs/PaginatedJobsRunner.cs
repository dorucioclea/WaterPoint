using System;
using System.Collections.Generic;
using System.Linq;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners.Jobs
{
    public class PaginatedJobsRunner : IPaginatedEntitiesRunner<Job>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public PaginatedJobsRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public PaginatedPoco<IEnumerable<Job>> Run(IQuery query)
        {
            var rawResults = _dapperDbContext
                .List<Job, PaginatedPoco>(
                    query.Query,
                    PaginatedPoco.SplitOnColumn,
                    query.Parameters)
                .ToArray();

            if (!rawResults.Any())
                return null;

            var result = new PaginatedPoco<IEnumerable<Job>>
            {
                TotalCount = rawResults.First().Item2.TotalCount,
                Data = rawResults.Select(i => i.Item1)
            };

            return result;
        }
    }
}
