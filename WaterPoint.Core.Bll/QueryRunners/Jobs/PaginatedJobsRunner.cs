using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
