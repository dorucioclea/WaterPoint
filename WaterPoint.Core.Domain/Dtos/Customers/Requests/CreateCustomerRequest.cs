using WaterPoint.Core.Domain.Dtos.Customers.Payloads;

namespace WaterPoint.Core.Domain.Dtos.Customers.Requests
{
    public class CreateCustomerRequest : IRequest
    {
        public OrganizationIdParameter OrganizationIdParameter { get; set; }
        public CreateCustomerPayload CreateCustomerPayload { get; set; }
    }
}
