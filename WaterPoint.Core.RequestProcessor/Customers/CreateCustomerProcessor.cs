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
        IWriteRequestProcessor<CreateCustomerRequest>
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

        public CommandResult Process(CreateCustomerRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, "customer", result > 0);
        }

        private int ProcessDeFacto(CreateCustomerRequest input)
        {
            #region  replace this with a proper mapper
            var createCustomerPoco = input.Payload.MapTo(new CreateCustomer());

            createCustomerPoco.OrganizationId = input.OrganizationId;
            #endregion

            _command.BuildQuery(createCustomerPoco);

            return  _executor.Execute(_command);
        }
    }
}
