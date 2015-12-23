using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Bll.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners.JobTasks
{
    public class ListJobTasksRunner : IListEntitiesRunner<ListJobTasks, JobTask>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public ListJobTasksRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public PaginatedPoco<IEnumerable<JobTask>> Run(IQuery<ListJobTasks> query)
        {
            var rawResults = _dapperDbContext
                .List<JobTask, PaginatedPoco>(
                    query.Query,
                    PaginatedPoco.SplitOnColumn,
                    query.Parameters)
                .ToArray();

            if (!rawResults.Any())
                return null;

            var result = new PaginatedPoco<IEnumerable<JobTask>>
            {
                TotalCount = rawResults.First().Item2.TotalCount,
                Data = rawResults.Select(i => i.Item1)
            };

            return result;
        }
    }
}
