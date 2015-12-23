using System.Linq;
using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.Bll.QueryRunners.Jobs
{
    public class GetJobDetailsRunner: IQueryRunner<GetJob, JobWithDetailsPoco>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetJobDetailsRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public JobWithDetailsPoco Run(IQuery<GetJob> query)
        {
            var job = _dapperDbContext
                .List<JobWithDetailsPoco>(query.Query, query.Parameters)
                .SingleOrDefault();

            return job;
        }
    }
}
