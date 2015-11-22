using System.Linq;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.QueryRunners.Customers
{
    public class GetCustomerByIdQueryRunner
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetCustomerByIdQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public Customer Run(IQuery query)
        {
            var customer = _dapperDbContext
                .List<Customer>(query.Query, query.Parameters)
                .SingleOrDefault();

            return customer;
        }
    }
}
