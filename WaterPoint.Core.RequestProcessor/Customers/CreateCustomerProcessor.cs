using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using Utility;
using WaterPoint.Core.Bll.QueryParameters.Customers;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class CreateCustomerProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateCustomerRequest, CustomerContract>
    {
        private readonly ICommand<CreateCustomerQueryParameter> _command;
        private readonly ICommandExecutor<CreateCustomerQueryParameter> _executor;
        private readonly IQuery<GetCustomerQueryParameter> _getCustomerQuery;
        private readonly IQueryRunner<GetCustomerQueryParameter, Customer> _getCustomerByIdQueryRunner;

        public CreateCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateCustomerQueryParameter> command,
            ICommandExecutor<CreateCustomerQueryParameter> executor,
            IQuery<GetCustomerQueryParameter> getCustomerQuery,
            IQueryRunner<GetCustomerQueryParameter, Customer> getCustomerByIdQueryRunner)
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
            var createCustomerPoco = input.CreateCustomerPayload.MapTo(new CreateCustomerQueryParameter());

            createCustomerPoco.OrganizationId = input.OrganizationIdParameter.OrganizationId;
            #endregion

            _command.BuildQuery(createCustomerPoco);

            var newId = _executor.Execute(_command);

            _getCustomerQuery.BuildQuery(new GetCustomerQueryParameter
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
