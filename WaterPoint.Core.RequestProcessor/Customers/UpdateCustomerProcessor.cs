using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.Customers;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class UpdateCustomerProcessor :
        BaseUpdateProcessor<UpdateCustomerRequest, WriteCustomerPayload, UpdateCustomer, GetCustomer, Customer>
    {
        public UpdateCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchAdapter,
            IQuery<GetCustomer> getQuery,
            IQueryRunner<GetCustomer, Customer> getRunner,
            ICommand<UpdateCustomer> updateQuery,
            ICommandExecutor<UpdateCustomer> updateExecutor)
            : base(dapperUnitOfWork, patchAdapter, getQuery, getRunner, updateQuery, updateExecutor)
        {
        }

        public override GetCustomer BuildGetParameter(UpdateCustomerRequest input)
        {
            var getCusParam = new GetCustomer
            {
                CustomerId = input.Id,
                OrganizationId = input.OrganizationId
            };

            return getCusParam;
        }
    }
}
