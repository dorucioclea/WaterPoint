using WaterPoint.Core.Domain.Payloads.QuoteCostItems;

namespace WaterPoint.Core.Domain.Requests.QuoteCostItems
{
    public class CreateQuoteCostItemRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int QuoteId { get; set; }
        public CreateQuoteCostItemPayload Payload { get; set; }
    }
}
