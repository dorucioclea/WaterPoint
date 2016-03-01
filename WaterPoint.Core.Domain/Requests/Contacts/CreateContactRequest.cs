using WaterPoint.Core.Domain.Payloads.Contacts;

namespace WaterPoint.Core.Domain.Requests.Contacts
{
    public class CreateContactRequest : ICreateRequest<WriteContactPayload>
    {
        public int OrganizationId { get; set; }
        public WriteContactPayload Payload { get; set; }
    }
}