using Utility;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobCostItems;
using WaterPoint.Core.Domain.Requests.InvoiceJobCostItems;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.InvoiceJobCostItems
{
    public class CreateInvoiceJobCostItemProcessor
        : BaseCreateProcessor<CreateInvoiceJobCostItemRequest, CreateInvoiceJobCostItem>
    {
        public CreateInvoiceJobCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateInvoiceJobCostItem> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateInvoiceJobCostItem BuildParameter(CreateInvoiceJobCostItemRequest input)
        {
            var createInvoiceJobCostItem = input.MapTo(new CreateInvoiceJobCostItem());

            input.Payload.MapTo(createInvoiceJobCostItem);

            return createInvoiceJobCostItem;
        }
    }
}
