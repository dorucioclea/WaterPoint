using System.Collections.Generic;
using Utility;
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
            _paginationAnalyzer.Analyze(input.PaginationParamter, "Id")
                .MapTo(new PaginatedWithOrgIdQueryParameter())

            _paginatedJobsQuery.BuildQuery();.BuildQuery(
                    input.OrganizationIdParameter.OrganizationId,
                    _paginationAnalyzer.Offset,
                    _paginationAnalyzer.PageSize,
                    _paginationAnalyzer.Sort,
                    _paginationAnalyzer.IsDesc,
                    _paginationAnalyzer.SearchTerm);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedEntitiesRunner.Run(_paginatedWithOrgIdQuery);

                return (result != null)
                    ? new PaginatedResult<IEnumerable<TContract>>
                    {
                        Data = result.Data.Select(Map),
                        TotalCount = result.TotalCount,
                        PageNumber = _paginationAnalyzer.PageNumber,
                        PageSize = _paginationAnalyzer.PageSize,
                        Sort = _paginationAnalyzer.Sort,
                        IsDesc = _paginationAnalyzer.IsDesc
                    }
                    : null;
            }
        }
    }

}
