using System.Collections.Generic;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class PaginatedCustomersProcessor :
        PaginatedEntitiesWithOrgIdProcessor<Customer, CustomerContract>,
        IRequestProcessor<PaginationWithOrgIdRequest, PaginatedResult<IEnumerable<CustomerContract>>>
    {

        public PaginatedCustomersProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            PaginationAnalyzer paginationAnalyzer,
            IPaginatedWithOrgIdQuery paginatedCustomersQuery,
            IPaginatedEntitiesRunner<Customer> paginatedCustomerRunner)
            : base(dapperUnitOfWork, paginationAnalyzer, paginatedCustomersQuery, paginatedCustomerRunner)
        {

        }

        public override CustomerContract Map(Customer source)
        {
            return CustomerMapper.Map(source);
        }
    }
}
