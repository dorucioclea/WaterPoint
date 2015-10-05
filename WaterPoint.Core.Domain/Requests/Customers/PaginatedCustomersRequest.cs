using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class PaginatedCustomersRequest : PaginationRequest
    {
        public int OrganizationId { get; set; }
    }
}
