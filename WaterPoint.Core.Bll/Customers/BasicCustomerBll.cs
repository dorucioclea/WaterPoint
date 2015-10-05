using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Blls;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.Customers
{
    public class BasicCustomerBll : BaseBll, IBasicCustomerBll
    {
        public BasicCustomerBll(IDapperUnitOfWork dapperUnitOfWork)
            : base(dapperUnitOfWork)
        {
        }

        public IEnumerable<BasicCustomerPoco> ListByOrgId(int orgId)
        {
            return Repository.List<BasicCustomerPoco>("", null);
        }
    }
}
