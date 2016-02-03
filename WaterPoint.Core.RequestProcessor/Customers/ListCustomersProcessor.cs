using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Bll.QueryRunners;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class ListCustomersProcessor :
        PagedProcessor<ListCustomersRequest, ListCustomers, Customer, CustomerContract>
    {
        public ListCustomersProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListCustomers, Customer> listQuery,
            IPagedQueryRunner listQueryRunner)
            : base(dapperUnitOfWork, listQuery, listQueryRunner)
        {
        }

        public override CustomerContract Map(Customer source)
        {
            return CustomerMapper.Map(source);
        }
    }
}
