using Utility;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteCostItems;
using WaterPoint.Core.Domain.QueryParameters.Quotes;
using WaterPoint.Core.Domain.Requests.QuoteCostItems;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.QuoteCostItems
{
    public class CreateQuoteCostItemProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<CreateQuoteCostItemRequest>
    {
        private readonly ICommand<CreateQuoteCostItem> _command;
        private readonly ICommandExecutor<CreateQuoteCostItem> _executor;

        public CreateQuoteCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateQuoteCostItem> command,
            ICommandExecutor<CreateQuoteCostItem> executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public CommandResult Process(CreateQuoteCostItemRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, "Quote cost", result > 0);
        }

        private static CreateQuoteCostItem GetParameter(CreateQuoteCostItemRequest input)
        {
            var createQuoteCostItem = input.MapTo(new CreateQuoteCostItem());

            input.Payload.MapTo(createQuoteCostItem);

            return createQuoteCostItem;
        }

        private int ProcessDeFacto(CreateQuoteCostItemRequest input)
        {
            var createQuote = GetParameter(input);

            _command.BuildQuery(createQuote);

            return _executor.Execute(_command);
        }
    }
}
