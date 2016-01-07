using WaterPoint.Core.Domain.Payloads.InvoiceJobCostItems;

namespace WaterPoint.Core.Domain.Requests.InvoiceJobCostItems
{
    public class CreateInvoiceJobCostItemRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int InvoiceId { get; set; }
        public CreateInvoiceJobCostItemPayload Payload { get; set; }
    }
}
