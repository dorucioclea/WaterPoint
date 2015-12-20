using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Dtos.Parameters
{
    public class CustomerIdOrgIdParameter
    {
        public int OrganizationId { get; set; }

        public int CustomerId { get; set; }
    }
}
