using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Domain.Blls
{
    public interface IBasicCustomerBll
    {
        IEnumerable<BasicCustomerPoco> ListByOrgId(int orgId);
    }
}
