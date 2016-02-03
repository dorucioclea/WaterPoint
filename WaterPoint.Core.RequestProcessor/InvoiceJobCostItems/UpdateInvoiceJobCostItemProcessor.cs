using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.InvoiceJobCostItems;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobCostItems;
using WaterPoint.Core.Domain.Requests.InvoiceJobCostItems;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.InvoiceJobCostItems
{
    public class UpdateInvoiceJobCostItemProcessor :
        BaseUpdateProcessor<UpdateInvoiceJobCostItemRequest, UpdateInvoiceJobCostItemPayload, UpdateInvoiceJobCostItem, GetInvoiceJobCostItem, InvoiceJobCostItem>
    {
        public UpdateInvoiceJobCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            ICommand<UpdateInvoiceJobCostItem> command,
            ICommandExecutor executor,
            IQuery<GetInvoiceJobCostItem, InvoiceJobCostItem> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork, patchEntityAdapter, query, runner, command, executor)
        {
        }

        public override GetInvoiceJobCostItem BuildGetParameter(UpdateInvoiceJobCostItemRequest input)
        {
            var getInvoiceJobCostItemParam = new GetInvoiceJobCostItem
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId,
                InvoiceId = input.InvoiceId
            };

            return getInvoiceJobCostItemParam;
        }
    }
}
