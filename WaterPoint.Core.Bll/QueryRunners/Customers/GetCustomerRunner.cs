using System.Linq;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.QueryRunners.Customers
{
    public class GetCustomerRunner : IQueryRunner<GetCustomer, Customer>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetCustomerRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public Customer Run(IQuery<GetCustomer> query)
        {
            var customer = _dapperDbContext
                .List<Customer>(query.Query, query.Parameters)
                .SingleOrDefault();

            return customer;
        }
    }
}
