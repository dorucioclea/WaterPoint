using WaterPoint.Core.Domain.QueryParameters.CostItems;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.CostItems;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.CostItems
{
    public class CreateCostItemProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateCostItemRequest, CommandResultContract>
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

        public CommandResultContract Process(CreateCostItemRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResultContract(result, "cost item", result > 0);
        }

        private int ProcessDeFacto(CreateCostItemRequest input)
        {
            var parameter = new CreateCostItem
            {
                OrganizationId = input.OrganizationIdParameter.OrganizationId,
                Code = input.CreateCustomerPayload.Code,
                IsBillable = input.CreateCustomerPayload.IsBillable,
                LongDescription = input.CreateCustomerPayload.LongDescription,
                ShortDescription = input.CreateCustomerPayload.ShortDescription,
                SupplierId = input.CreateCustomerPayload.SupplierId,
                UnitCost = input.CreateCustomerPayload.UnitCost,
                UnitPrice = input.CreateCustomerPayload.UnitPrice
            };

            _command.BuildQuery(parameter);

            return _executor.Execute(_command);
        }
    }
}
