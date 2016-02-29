using WaterPoint.Core.Domain.Payloads.Contacts;

namespace WaterPoint.Core.Domain.Requests.Contacts
{
    public class CreateContactForCustomerRequest : ICreateRequest<WriteContactPayload>
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public WriteContactPayload Payload { get; set; }
    }
}
