using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using Utility;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class CreateCustomerProcessor : BaseCreateProcessor<CreateCustomerRequest, CreateCustomer>
    {
        public CreateCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateCustomer> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateCustomer BuildParameter(CreateCustomerRequest input)
        {
            var createCustomer = input.Payload.MapTo(new CreateCustomer());

            createCustomer.OrganizationId = input.OrganizationId;

            return createCustomer;
        }
    }
}
