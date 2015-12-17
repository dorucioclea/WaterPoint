using System.Collections.Generic;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos.Parameters;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class ListPaginatedJobsProcessor :
        IRequestProcessor<ListPaginatedWithOrgIdRequest, PaginatedResult<IEnumerable<JobContract>>>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IListPaginatedEntitiesRunner<Job> _paginatedJobRunner;
        private readonly PaginationAnalyzer _paginationAnalyzer;
        private readonly IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter> _paginatedJobsQuery;

        public ListPaginatedJobsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IListPaginatedEntitiesRunner<Job> paginatedJobRunner,
            PaginationAnalyzer paginationAnalyzer,
            IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter> paginatedJobsQuery)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginatedJobRunner = paginatedJobRunner;
            _paginationAnalyzer = paginationAnalyzer;
            _paginatedJobsQuery = paginatedJobsQuery;
        }

        public JobContract Map(Job source)
        {
            return JobMapper.Map(source);
        }

        public PaginatedResult<IEnumerable<JobContract>> Process(ListPaginatedWithOrgIdRequest input)
        {
            throw new System.NotImplementedException();
        }
    }

}
