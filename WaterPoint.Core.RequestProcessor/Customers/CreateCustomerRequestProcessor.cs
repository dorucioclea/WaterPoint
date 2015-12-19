using WaterPoint.Core.Bll.Commands.Customers;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using Utility;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Core.Bll.QueryRunners.Customers;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class CreateCustomerRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateCustomerRequest, CustomerContract>
    {
        private readonly CreateCustomerCommand _command;
        private readonly CreateCommandExecutor _executor;
        private readonly GetCustomerByIdQuery _getCustomerQuery;
        private readonly GetCustomerByIdQueryRunner _getCustomerByIdQueryRunner;

        public CreateCustomerRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            CreateCustomerCommand command,
            CreateCommandExecutor executor,
            GetCustomerByIdQuery getCustomerQuery,
            GetCustomerByIdQueryRunner getCustomerByIdQueryRunner)
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

            var newId = _executor.Run(_command);

            _getCustomerQuery.BuildQuery(input.OrganizationIdParameter.OrganizationId, newId);

            var customer = _getCustomerByIdQueryRunner.Run(_getCustomerQuery);

            var result = CustomerMapper.Map(customer);

            return result;
        }
    }
}
