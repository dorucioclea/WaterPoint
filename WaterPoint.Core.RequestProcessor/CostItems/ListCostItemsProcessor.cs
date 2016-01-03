using System.Linq;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.Shared;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.CostItems;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.CostItems
{
    public class ListCostItemsProcessor : IPaginatedProcessor<ListCostItemsRequest, CostItemContract>
    {
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly PaginationQueryParameterConverter _paginationQueryParameterConverter;
        private readonly IQuery<PaginatedOrgId> _paginatedcostItemsQuery;
        private readonly IListQueryRunner<PaginatedOrgId, CostItem> _paginatedcostItemRunner;

        public ListCostItemsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            PaginationQueryParameterConverter paginationQueryParameterConverter,
            IQuery<PaginatedOrgId> paginatedcostItemsQuery,
            IListQueryRunner<PaginatedOrgId, CostItem> paginatedcostItemRunner)
        {
            _dapperUnitOfWork = dapperUnitOfWork;
            _paginationQueryParameterConverter = paginationQueryParameterConverter;
            _paginatedcostItemsQuery = paginatedcostItemsQuery;
            _paginatedcostItemRunner = paginatedcostItemRunner;
        }

        public CostItemContract Map(CostItem source)
        {
            return CostItemMapper.Map(source);
        }

        public PaginatedResult<CostItemContract> Process(ListCostItemsRequest input)
        {
            var parameter = _paginationQueryParameterConverter.Convert(input, "Id")
                .MapTo(new PaginatedOrgId());

            parameter.OrganizationId = input.OrganizationId;

            _paginatedcostItemsQuery.BuildQuery(parameter);

            using (_dapperUnitOfWork.Begin())
            {
                var result = _paginatedcostItemRunner.Run(_paginatedcostItemsQuery);

                return new PaginatedResult<CostItemContract>
                {
                    Data = result.Data.Select(Map),
                    TotalCount = result.TotalCount,
                    PageNumber = _paginationQueryParameterConverter.PageNumber,
                    PageSize = _paginationQueryParameterConverter.PageSize,
                    Sort = _paginationQueryParameterConverter.Sort,
                    IsDesc = _paginationQueryParameterConverter.IsDesc
                };
            }
        }
    }
}
