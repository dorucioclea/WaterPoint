using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Dtos.Shared.Requests;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor
{
    public abstract class PaginatedEntitiesWithOrgIdProcessor<TEntity, TContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly PaginationAnalyzer _paginationAnalyzer;
        private readonly IPaginatedWithOrgIdQuery _paginatedWithOrgIdQuery;
        private readonly IPaginatedEntitiesRunner<TEntity> _paginatedEntitiesRunner;

        protected PaginatedEntitiesWithOrgIdProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            PaginationAnalyzer paginationAnalyzer,
            IPaginatedWithOrgIdQuery paginatedWithOrgIdQuery,
            IPaginatedEntitiesRunner<TEntity> paginatedEntitiesRunner
            )
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginationAnalyzer = paginationAnalyzer;
            _paginatedWithOrgIdQuery = paginatedWithOrgIdQuery;
            _paginatedEntitiesRunner = paginatedEntitiesRunner;
        }

        public PaginatedResult<IEnumerable<TContract>> Process(PaginationWithOrgIdRequest input)
        {
            _paginationAnalyzer.Analyze(input.PaginationParamter, "Id");

            _paginatedWithOrgIdQuery.BuildQuery(
                    input.OrganizationIdParameter.OrganizationId,
                    _paginationAnalyzer.Offset,
                    _paginationAnalyzer.PageSize,
                    _paginationAnalyzer.Sort,
                    _paginationAnalyzer.IsDesc);

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

        public abstract TContract Map(TEntity source);
    }
}
