using WaterPoint.Api.Common;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.QuoteCostItems;
using WaterPoint.Core.Domain.QueryParameters.QuoteCostItems;
using WaterPoint.Core.Domain.Requests.QuoteCostItems;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.QuoteCostItems
{
    public class UpdateQuoteCostItemProcessor :
        BaseUpdateProcessor<UpdateQuoteCostItemRequest, UpdateQuoteCostItemPayload, UpdateQuoteCostItem, GetQuoteCostItem, QuoteCostItem>
    {
        public UpdateQuoteCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            ICommand<UpdateQuoteCostItem> command,
            ICommandExecutor executor,
            IQuery<GetQuoteCostItem, QuoteCostItem> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork, patchEntityAdapter, query, runner, command, executor)
        {
        }

        public override GetQuoteCostItem BuildGetParameter(UpdateQuoteCostItemRequest input)
        {
            var getQuoteCostItemParam = new GetQuoteCostItem
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId,
                QuoteId = input.QuoteId
            };

            return getQuoteCostItemParam;
        }
    }
}
