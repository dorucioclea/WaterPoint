using System.Linq;
using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.Bll.QueryRunners.Jobs
{
    public class GetJobByIdQueryRunner: IQueryRunner<GetJobDetails, JobWithDetailsPoco>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetJobByIdQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public JobWithDetailsPoco Run(IQuery<GetJobDetails> query)
        {
            var job = _dapperDbContext
                .List<JobWithDetailsPoco>(query.Query, query.Parameters)
                .SingleOrDefault();

            return job;
        }
    }
}
