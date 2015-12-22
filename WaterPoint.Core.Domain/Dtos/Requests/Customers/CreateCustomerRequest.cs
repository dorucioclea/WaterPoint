using WaterPoint.Core.Domain.Dtos.Payloads.Customers;

namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class CreateCustomerRequest : IRequest
    {
        public OrgIdParameter OrganizationIdParameter { get; set; }
        public WriteCustomerPayload CreateCustomerPayload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
