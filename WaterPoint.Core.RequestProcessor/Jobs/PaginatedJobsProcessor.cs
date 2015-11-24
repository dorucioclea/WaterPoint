using System.Collections.Generic;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class PaginatedJobsProcessor : PaginatedEntitiesWithOrgIdProcessor<Job, JobContract>,
        IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<JobContract>>>
    {
        public PaginatedJobsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPaginatedEntitiesRunner<Job> paginatedJobRunner,
            PaginationAnalyzer paginationAnalyzer,
            IPaginatedWithOrgIdQuery paginatedJobsQuery)
            : base(dapperUnitOfWork, paginationAnalyzer, paginatedJobsQuery, paginatedJobRunner)
        {
        }

        public override JobContract Map(Job source)
        {
            return JobMapper.Map(source);
        }
    }

}
