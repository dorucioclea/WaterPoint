using System.Collections.Generic;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class DeleteCustomersRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public IEnumerable<int> Customer { get; set; }
    }
}
