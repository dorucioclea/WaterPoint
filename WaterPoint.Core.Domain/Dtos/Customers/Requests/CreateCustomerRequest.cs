using WaterPoint.Core.Domain.Dtos.Customers.Payloads;

namespace WaterPoint.Core.Domain.Dtos.Customers.Requests
{
    public class CreateCustomerRequest : IRequest
    {
        public OrganizationIdParameter OrganizationIdParameter { get; set; }
        public WriteCustomerPayload CreateCustomerPayload { get; set; }
    }
}
