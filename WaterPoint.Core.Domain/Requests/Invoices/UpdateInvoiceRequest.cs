using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.Invoices;

namespace WaterPoint.Core.Domain.Requests.Invoices
{
    public class UpdateInvoiceRequest : IUpdateRequest<WriteInvoicePayload>
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
        public Delta<WriteInvoicePayload> Payload { get; set; }
    }
}
