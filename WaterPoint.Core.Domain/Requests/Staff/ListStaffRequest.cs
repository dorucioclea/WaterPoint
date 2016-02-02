using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Requests.Staff
{
    public class ListStaffRequest : IRequest
    {
        public int OrganizationId { get; set; }
    }
}
