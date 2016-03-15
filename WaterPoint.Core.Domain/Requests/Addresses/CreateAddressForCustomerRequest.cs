using WaterPoint.Core.Domain.Payloads.Addresses;

namespace WaterPoint.Core.Domain.Requests.Addresses
{
    public class CreateCustomerAddressRequest : ICreateRequest<WriteCustomerAddressPayload>
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public WriteCustomerAddressPayload Payload { get; set; }
    }
}
