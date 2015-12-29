using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.RequestParameters.Interfaces;

namespace WaterPoint.Core.Domain.RequestParameters
{
    public class OrgIdCusIdJobId: IOrgId
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public int JobId { get; set; }
    }
}
