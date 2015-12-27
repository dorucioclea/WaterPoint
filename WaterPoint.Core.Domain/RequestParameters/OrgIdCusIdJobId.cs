using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.RequestParameters
{
    public class OrgIdCusIdJobId : IUriPathParameter
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public int JobId { get; set; }
    }
}
