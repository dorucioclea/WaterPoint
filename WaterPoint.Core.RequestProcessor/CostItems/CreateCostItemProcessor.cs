using WaterPoint.Core.Bll.QueryParameters.CostItems;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.CostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.CostItems;
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

            return result;
        }

        private CommandResultContract ProcessDeFacto(CreateCostItemRequest input)
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

            var newId = _executor.Execute(_command);

            if(newId > 0)
                return new CommandResultContract
                {
                    Data = newId,
                    Message = $"cost item {newId} has been created",
                    Status = CommandResultContract.Success
                };

            return new CommandResultContract
            {
                Data = null,
                Message = "operation is finished but there is no result returned",
                Status = CommandResultContract.Failed
            };
        }
    }
}
