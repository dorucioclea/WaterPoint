using System.Linq;
using WaterPoint.Core.Bll.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.QueryRunners.JobTasks
{
    public class GetJobTaskRunner: IQueryRunner<GetJobTask, JobTask>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetJobTaskRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public JobTask Run(IQuery<GetJobTask> query)
        {
            var jobTask = _dapperDbContext
                .List<JobTask>(query.Query, query.Parameters)
                .SingleOrDefault();

            return jobTask;
        }
    }
}
