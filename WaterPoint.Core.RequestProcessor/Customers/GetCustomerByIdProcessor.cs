using AutoMapper.Internal;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Bll.QueryParameters.Customers;
using WaterPoint.Core.Bll.QueryRunners.Customers;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class GetCustomerByIdProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetCustomerByIdRequest, CustomerContract>
    {
        private readonly IQuery<GetCustomerQueryParameter> _query;
        private readonly GetCustomerByIdQueryRunner _runner;

        public GetCustomerByIdProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetCustomerQueryParameter> query,
            GetCustomerByIdQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public CustomerContract Process(GetCustomerByIdRequest input)
        {
            var parameter = new GetCustomerQueryParameter
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
