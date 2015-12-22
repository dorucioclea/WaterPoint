using AutoMapper.Internal;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Bll.QueryParameters.Customers;
using WaterPoint.Core.Bll.QueryRunners.Customers;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class GetCustomerProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetCustomerRequest, CustomerContract>
    {
        private readonly IQuery<GetCustomer> _query;
        private readonly IQueryRunner<GetCustomer, Customer> _runner;

        public GetCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetCustomer> query,
            IQueryRunner<GetCustomer, Customer> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public CustomerContract Process(GetCustomerRequest input)
        {
            var parameter = new GetCustomer
            {
                OrganizationId = input.OrganizationEntityParameter.OrganizationId,
                CustomerId = input.OrganizationEntityParameter.Id
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var customer = _runner.Run(_query);

                var result = CustomerMapper.Map(customer);

                return result;
            }
        }
    }
}
