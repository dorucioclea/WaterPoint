using System.Collections.Generic;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class ListPaginatedJobTasksProcessor :
        IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<JobTaskContract>>>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IListPaginatedEntitiesRunner<JobTask> _paginatedJobTaskRunner;
        private readonly PaginationAnalyzer _paginationAnalyzer;
        private readonly IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter> _paginatedJobTasksQuery;

        public ListPaginatedJobTasksProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListPaginatedEntitiesRunner<JobTask> paginatedJobTaskRunner,
            PaginationAnalyzer paginationAnalyzer,
            IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter> paginatedJobTasksQuery)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginatedJobTaskRunner = paginatedJobTaskRunner;
            _paginationAnalyzer = paginationAnalyzer;
            _paginatedJobTasksQuery = paginatedJobTasksQuery;
        }

        public JobTaskContract Map(JobTask source)
        {
            return JobTaskMapper.Map(source);
        }

        public PaginatedResult<IEnumerable<JobTaskContract>> Process(ListPaginatedWithOrgIdRequest input)
        {
            throw new System.NotImplementedException();
        }
    }

}
