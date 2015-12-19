using System.Linq;
using WaterPoint.Core.Domain;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.QueryRunners.JobTasks
{
    public class GetJobTaskByIdQueryRunner
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetJobTaskByIdQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public JobTask Run(IQuery query)
        {
            var jobTask = _dapperDbContext
                .List<JobTask>(query.Query, query.Parameters)
                .SingleOrDefault();

            return jobTask;
        }
    }
}
