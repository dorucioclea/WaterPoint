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
    public class ListPaginatedJobTasksProcessor : PaginatedEntitiesWithOrgIdProcessor<JobTask, JobTaskContract>,
        IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<JobTaskContract>>>
    {
        public ListPaginatedJobTasksProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListPaginatedEntitiesRunner<JobTask> paginatedJobTaskRunner,
            PaginationAnalyzer paginationAnalyzer,
            IListPaginatedWithOrgIdQuery paginatedJobTasksQuery)
            : base(dapperUnitOfWork, paginationAnalyzer, paginatedJobTasksQuery, paginatedJobTaskRunner)
        {
        }

        public override JobTaskContract Map(JobTask source)
        {
            return JobTaskMapper.Map(source);
        }
    }

}
