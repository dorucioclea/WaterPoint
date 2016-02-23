using WaterPoint.Core.Domain.Payloads.Addresses;

namespace WaterPoint.Core.Domain.Requests.Addresses
{
    public class CreateAddressForCustomerRequest : ICreateRequest<WriteAddressPayload>
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public WriteAddressPayload Payload { get; set; }
    }
}
