using WaterPoint.Core.Domain.Payloads.InvoiceCostItems;

namespace WaterPoint.Core.Domain.Requests.InvoiceCostItems
{
    public class CreateInvoiceCostItemRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int InvoiceId { get; set; }
        public CreateInvoiceCostItemPayload Payload { get; set; }
    }
}
