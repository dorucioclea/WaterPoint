using Utility;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteCostItems;
using WaterPoint.Core.Domain.Requests.QuoteCostItems;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.QuoteCostItems
{
    public class CreateQuoteCostItemProcessor : BaseCreateProcessor<CreateQuoteCostItemRequest, CreateQuoteCostItem>
    {
        public CreateQuoteCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateQuoteCostItem> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateQuoteCostItem BuildParameter(CreateQuoteCostItemRequest input)
        {
            var createQuoteCostItem = input.MapTo(new CreateQuoteCostItem());

            input.Payload.MapTo(createQuoteCostItem);

            return createQuoteCostItem;
        }
    }
}
