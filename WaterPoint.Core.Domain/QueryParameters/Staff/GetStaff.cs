using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Staff
{
    public class GetStaff : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
