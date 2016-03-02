using WaterPoint.Core.Domain.Payloads.Addresses;

namespace WaterPoint.Core.Domain.Requests.Addresses
{
    public class CreateAddressRequest : ICreateRequest<WriteAddressPayload>
    {
        public int OrganizationId { get; set; }
        public WriteAddressPayload Payload { get; set; }
    }
}
