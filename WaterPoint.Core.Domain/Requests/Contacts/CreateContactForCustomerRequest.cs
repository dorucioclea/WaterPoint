using WaterPoint.Core.Domain.Payloads.Contacts;

namespace WaterPoint.Core.Domain.Requests.Contacts
{
    public class CreateContactForCustomerRequest : ICreateRequest<CreateContactPayload>
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public CreateContactPayload Payload { get; set; }
    }
}