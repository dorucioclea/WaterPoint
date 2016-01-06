using WaterPoint.Core.Domain.Payloads.Invoices;

namespace WaterPoint.Core.Domain.Requests.Invoices
{
    public class CreateInvoiceRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public CreateInvoicePayload Payload { get; set; }
    }
}
