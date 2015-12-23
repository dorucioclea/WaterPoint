using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using Utility;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class CreateCustomerProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateCustomerRequest, CommandResultContract>
    {
        private readonly ICommand<CreateCustomer> _command;
        private readonly ICommandExecutor<CreateCustomer> _executor;

        public CreateCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateCustomer> command,
            ICommandExecutor<CreateCustomer> executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public CommandResultContract Process(CreateCustomerRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private CommandResultContract ProcessDeFacto(CreateCustomerRequest input)
        {
            #region  replace this with a proper mapper
            var createCustomerPoco = input.CreateCustomerPayload.MapTo(new CreateCustomer());

            createCustomerPoco.OrganizationId = input.OrganizationIdParameter.OrganizationId;
            #endregion

            _command.BuildQuery(createCustomerPoco);

            var newId = _executor.Execute(_command);

            if (newId > 0)
                return new CommandResultContract
                {
                    Data = newId,
                    Message = $"customer {newId} has been created",
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
