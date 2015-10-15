using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.Customers.Runners
{
    public class PaginatedCustomerQueryRunner : DapperQueryRunner<IEnumerable<BasicCustomerPoco>>
    {
        public PaginatedCustomerQueryRunner(IDapperDbContext dapperDbContext)
            : base(dapperDbContext)
        {
        }

        public override IEnumerable<BasicCustomerPoco> Run(IQuery query)
        {
            return Repository.List<BasicCustomerPoco>(query.Query, query.Parameters);
        }
    }
}
