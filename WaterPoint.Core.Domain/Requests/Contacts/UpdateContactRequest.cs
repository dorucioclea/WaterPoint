using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.Contacts;

namespace WaterPoint.Core.Domain.Requests.Contacts
{
    public class UpdateContactRequest : IUpdateRequest<WriteContactPayload>
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public Delta<WriteContactPayload> Payload { get; set; }
    }
}
