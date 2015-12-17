//using System.Collections.Generic;
//using System.Linq;
//using WaterPoint.Core.Bll.QueryParameters;
//using WaterPoint.Core.Bll.QueryRunners;
//using WaterPoint.Core.Domain;
//using WaterPoint.Core.Domain.Dtos.Requests.Shared;
//using WaterPoint.Data.DbContext.Dapper;

//namespace WaterPoint.Core.RequestProcessor
//{
//    public abstract class PaginatedEntitiesWithOrgIdProcessHelper<TEntity, TContract>
//    {
//        private readonly IDapperUnitOfWork _dapperUnitOfWork;
//        private readonly PaginationAnalyzer _paginationAnalyzer;
//        private readonly IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter> _paginatedWithOrgIdQuery;
//        private readonly IListPaginatedEntitiesRunner<TEntity> _paginatedEntitiesRunner;

//        protected PaginatedEntitiesWithOrgIdProcessHelper(
//            IDapperUnitOfWork dapperUnitOfWork,
//            PaginationAnalyzer paginationAnalyzer,
//            IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter> paginatedWithOrgIdQuery,
//            IListPaginatedEntitiesRunner<TEntity> paginatedEntitiesRunner
//            )
//        {
//            _dapperUnitOfWork = dapperUnitOfWork;
//            _paginationAnalyzer = paginationAnalyzer;
//            _paginatedWithOrgIdQuery = paginatedWithOrgIdQuery;
//            _paginatedEntitiesRunner = paginatedEntitiesRunner;
//        }

//        public PaginatedResult<IEnumerable<TContract>> Process(ListPaginatedWithOrgIdRequest input)
//        {
//            _paginationAnalyzer.Analyze(input.PaginationParamter, "Id");

//            _paginatedWithOrgIdQuery.BuildQuery(
//                    input.OrganizationIdParameter.OrganizationId,
//                    _paginationAnalyzer.Offset,
//                    _paginationAnalyzer.PageSize,
//                    _paginationAnalyzer.Sort,
//                    _paginationAnalyzer.IsDesc,
//                    _paginationAnalyzer.SearchTerm);

//            using (_dapperUnitOfWork.Begin())
//            {
//                var result = _paginatedEntitiesRunner.Run(_paginatedWithOrgIdQuery);

//                return (result != null)
//                    ? new PaginatedResult<IEnumerable<TContract>>
//                    {
//                        Data = result.Data.Select(Map),
//                        TotalCount = result.TotalCount,
//                        PageNumber = _paginationAnalyzer.PageNumber,
//                        PageSize = _paginationAnalyzer.PageSize,
//                        Sort = _paginationAnalyzer.Sort,
//                        IsDesc = _paginationAnalyzer.IsDesc
//                    }
//                    : null;
//            }
//        }

//        public abstract TContract Map(TEntity source);
//    }
//}
