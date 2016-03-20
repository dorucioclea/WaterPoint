using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.Contacts;

namespace WaterPoint.Core.Domain.Requests.Contacts
{
    public class UpdateCustomerContactRequest : IUpdateRequest<WriteCustomerContactPayload>
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public int ContactId { get; set; }
        public Delta<WriteCustomerContactPayload> Payload { get; set; }
    }
}