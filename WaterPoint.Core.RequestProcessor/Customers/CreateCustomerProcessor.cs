using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using Utility;
using WaterPoint.Core.Bll.QueryParameters.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class CreateCustomerProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateCustomerRequest, CustomerContract>
    {
        private readonly ICommand<CreateCustomer> _command;
        private readonly ICommandExecutor<CreateCustomer> _executor;
        private readonly IQuery<GetCustomer> _getCustomerQuery;
        private readonly IQueryRunner<GetCustomer, Customer> _getCustomerByIdQueryRunner;

        public CreateCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateCustomer> command,
            ICommandExecutor<CreateCustomer> executor,
            IQuery<GetCustomer> getCustomerQuery,
            IQueryRunner<GetCustomer, Customer> getCustomerByIdQueryRunner)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
            _getCustomerQuery = getCustomerQuery;
            _getCustomerByIdQueryRunner = getCustomerByIdQueryRunner;
        }

        public CustomerContract Process(CreateCustomerRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private CustomerContract ProcessDeFacto(CreateCustomerRequest input)
        {
            #region  replace this with a proper mapper
            var createCustomerPoco = input.CreateCustomerPayload.MapTo(new CreateCustomer());

            createCustomerPoco.OrganizationId = input.OrganizationIdParameter.OrganizationId;
            #endregion

            _command.BuildQuery(createCustomerPoco);

            var newId = _executor.Execute(_command);

            _getCustomerQuery.BuildQuery(new GetCustomer
            {
                OrganizationId = input.OrganizationIdParameter.OrganizationId,
                CustomerId = newId
            });

            var customer = _getCustomerByIdQueryRunner.Run(_getCustomerQuery);

            var result = CustomerMapper.Map(customer);

            return result;
        }
    }
}
