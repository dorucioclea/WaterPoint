using WaterPoint.Core.Domain.Payloads.Contacts;

namespace WaterPoint.Core.Domain.Requests.Contacts
{
    public class CreateCustomerContactRequest : ICreateRequest<CreateCustomerContactPayload>
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public CreateCustomerContactPayload Payload { get; set; }
    }
}
