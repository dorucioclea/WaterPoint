using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Bll.QueryRunners.Customers;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class GetCustomerByIdRequestProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetCustomerByIdRequest, CustomerContract>
    {
        private readonly GetCustomerByIdQuery _query;
        private readonly GetCustomerByIdQueryRunner _runner;

        public GetCustomerByIdRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            GetCustomerByIdQuery query,
            GetCustomerByIdQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public CustomerContract Process(GetCustomerByIdRequest input)
        {
            _query.BuildQuery(input.OrganizationEntityParameter.OrganizationId, input.OrganizationEntityParameter.Id);

            using (DapperUnitOfWork.Begin())
            {
                var customer = _runner.Run(_query);

                var result = CustomerMapper.Map(customer);

                return result;
            }
        }
    }
}
