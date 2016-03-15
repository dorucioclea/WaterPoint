using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.InvoiceCostItems;
using WaterPoint.Core.Domain.QueryParameters.InvoiceCostItems;
using WaterPoint.Core.Domain.Requests.InvoiceCostItems;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.InvoiceCostItems
{
    public class UpdateInvoiceCostItemProcessor :
        BaseUpdateProcessor<UpdateInvoiceCostItemRequest, UpdateInvoiceCostItemPayload, UpdateInvoiceCostItem, GetInvoiceCostItem, InvoiceCostItem>
    {
        public UpdateInvoiceCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            ICommand<UpdateInvoiceCostItem> command,
            ICommandExecutor executor,
            IQuery<GetInvoiceCostItem, InvoiceCostItem> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork, patchEntityAdapter, query, runner, command, executor)
        {
        }

        public override GetInvoiceCostItem BuildGetParameter(UpdateInvoiceCostItemRequest input)
        {
            var getInvoiceCostItemParam = new GetInvoiceCostItem
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId,
                InvoiceId = input.InvoiceId
            };

            return getInvoiceCostItemParam;
        }
    }
}
