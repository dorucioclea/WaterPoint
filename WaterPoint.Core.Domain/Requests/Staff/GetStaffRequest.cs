using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Requests.Staff
{
    public class GetStaffRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
