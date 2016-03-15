using WaterPoint.Core.Domain.Payloads.Invoices;

namespace WaterPoint.Core.Domain.Requests.Invoices
{
    public class CreateInvoiceRequest : ICreateRequest<WriteInvoicePayload>
    {
        public int OrganizationId { get; set; }
        public WriteInvoicePayload Payload { get; set; }
    }
}
