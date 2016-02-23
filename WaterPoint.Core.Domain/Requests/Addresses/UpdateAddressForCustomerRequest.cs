using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.Addresses;

namespace WaterPoint.Core.Domain.Requests.Addresses
{
    public class UpdateAddressForCustomerRequest : IUpdateRequest<WriteAddressPayload>
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public int Id { get; set; }
        public Delta<WriteAddressPayload> Payload { get; set; }
    }
}
