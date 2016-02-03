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
    public class ListCostItemsProcessor :
        PagedProcessor<ListCostItemsRequest, PagedOrgId, CostItem, CostItemContract>
    {
        public ListCostItemsProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<PagedOrgId> query,
            IPagedQueryRunner runner)
            : base(dapperUnitOfWork, query, runner)
        {
        }

        public override CostItemContract Map(CostItem source)
        {
            return CostItemMapper.Map(source);
        }
    }
}
