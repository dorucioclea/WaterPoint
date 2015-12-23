using WaterPoint.Core.Domain.Payloads.Customers;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class CreateCustomerRequest : IRequest
    {
        public OrgIdRp OrganizationIdParameter { get; set; }
        public WriteCustomerPayload CreateCustomerPayload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
