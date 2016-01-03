using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.CostItems;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.CostItems
{
    public class CreateCostItemProcessor : BaseDapperUowRequestProcess,
        IWriteRequestProcessor<CreateCostItemRequest>
    {
        private readonly ICommand<CreateCostItem> _command;
        private readonly ICommandExecutor<CreateCostItem> _executor;

        public CreateCostItemProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateCostItem> command,
            ICommandExecutor<CreateCostItem> executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public CommandResult Process(CreateCostItemRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, "cost item", result > 0);
        }

        private int ProcessDeFacto(CreateCostItemRequest input)
        {
            var parameter = new CreateCostItem
            {
                OrganizationId = input.OrganizationId,
                Code = input.Payload.Code,
                IsBillable = input.Payload.IsBillable,
                LongDescription = input.Payload.LongDescription,
                ShortDescription = input.Payload.ShortDescription,
                SupplierId = input.Payload.SupplierId,
                UnitCost = input.Payload.UnitCost,
                UnitPrice = input.Payload.UnitPrice
            };

            _command.BuildQuery(parameter);

            return _executor.Execute(_command);
        }
    }
}
