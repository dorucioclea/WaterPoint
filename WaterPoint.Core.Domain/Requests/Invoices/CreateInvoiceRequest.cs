using WaterPoint.Core.Domain.Payloads.Invoices;

namespace WaterPoint.Core.Domain.Requests.Invoices
{
    public class CreateInvoiceRequest : ICreateRequest<CreateInvoicePayload>
    {
        public int OrganizationId { get; set; }
        public CreateInvoicePayload Payload { get; set; }
    }
}
