using WaterPoint.Core.Domain.Dtos.Payloads.Customers;

namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class CreateCustomerRequest : IRequest
    {
        public OrganizationIdParameter OrganizationIdParameter { get; set; }
        public WriteCustomerPayload CreateCustomerPayload { get; set; }
        public int StaffId { get; set; }
    }
}
