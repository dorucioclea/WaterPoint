using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.Customers.Runners
{
    public class GetCustomerByIdQueryRunner
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetCustomerByIdQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public CustomerPoco Run(IQuery query)
        {
            var customer = _dapperDbContext
                .List<CustomerPoco>(query.Query, query.Parameters)
                .SingleOrDefault();

            return customer;
        }
    }
}
