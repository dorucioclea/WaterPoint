using System.Collections.Generic;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class PaginatedJobTasksProcessor : PaginatedEntitiesWithOrgIdProcessor<JobTask, JobTaskContract>,
        IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<JobTaskContract>>>
    {
        public PaginatedJobTasksProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPaginatedEntitiesRunner<JobTask> paginatedJobTaskRunner,
            PaginationAnalyzer paginationAnalyzer,
            IPaginatedWithOrgIdQuery paginatedJobTasksQuery)
            : base(dapperUnitOfWork, paginationAnalyzer, paginatedJobTasksQuery, paginatedJobTaskRunner)
        {
        }

        public override JobTaskContract Map(JobTask source)
        {
            return JobTaskMapper.Map(source);
        }
    }

}
