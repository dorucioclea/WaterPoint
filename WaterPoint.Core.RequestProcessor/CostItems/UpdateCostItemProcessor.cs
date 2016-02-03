using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.CostItems;
using WaterPoint.Core.Domain.Payloads.QuoteCostItems;
using WaterPoint.Core.Domain.Requests.CostItems;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.CostItems
{
    public class UpdateCostItemProcessor
        : BaseUpdateProcessor<UpdateCostItemRequest, WriteCostItemPayload, UpdateCostItem, GetCostItem, CostItem>
    {
        public UpdateCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter adapter,
            IQuery<GetCostItem, CostItem> getQuery,
            IQueryRunner getQueryRunner,
            ICommand<UpdateCostItem> updateQuery,
            ICommandExecutor updateExecutor)
            : base(dapperUnitOfWork, adapter, getQuery, getQueryRunner, updateQuery, updateExecutor)
        {
        }

        public override GetCostItem BuildGetParameter(UpdateCostItemRequest input)
        {
            var getParam = new GetCostItem
            {
                CostItemId = input.Id,
                OrganizationId = input.OrganizationId
            };

            return getParam;
        }
    }
}
