using Utility;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceCostItems;
using WaterPoint.Core.Domain.Requests.InvoiceCostItems;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.InvoiceCostItems
{
    public class CreateInvoiceCostItemProcessor
        : BaseCreateProcessor<CreateInvoiceCostItemRequest, CreateInvoiceCostItem>
    {
        public CreateInvoiceCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateInvoiceCostItem> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateInvoiceCostItem BuildParameter(CreateInvoiceCostItemRequest input)
        {
            var createInvoiceCostItem = input.MapTo(new CreateInvoiceCostItem());

            input.Payload.MapTo(createInvoiceCostItem);

            return createInvoiceCostItem;
        }
    }
}
