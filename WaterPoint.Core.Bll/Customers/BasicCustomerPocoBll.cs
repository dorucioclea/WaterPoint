using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Bll.Enum;
using WaterPoint.Core.Domain.Blls;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.Customers
{
    public class BasicCustomerPocoBll : BaseBll, IBasicCustomerBll
    {
        public BasicCustomerPocoBll(IDapperDbContext dapperDbContext, ISqlBuilderFactory sqlBuilderFactory)
            : base(dapperDbContext, sqlBuilderFactory)
        {
        }

        public IEnumerable<BasicCustomerPoco> ListByOrgId(int orgId)
        {
            var builder = SqlBuilderFactory.Create<BasicCustomerPoco>(Crud.Read);

            builder.GetSql<BasicCustomerPoco>(i => new {i.OrganizationId});

            return Repository.List<BasicCustomerPoco>(builder.GetSql(), new
            {
                OrganizationId = orgId
            });
        }
    }
}
