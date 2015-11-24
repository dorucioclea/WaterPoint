using System.Linq;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.QueryRunners.Jobs
{
    public class GetJobByIdQueryRunner
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetJobByIdQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public Job Run(IQuery query)
        {
            var job = _dapperDbContext
                .List<Job>(query.Query, query.Parameters)
                .SingleOrDefault();

            return job;
        }
    }
}
