using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.QuoteCostItems
{
    public class GetQuoteCostItemRequest : IRequest, IOrgEntity
    {
        public int QuoteId { get; set; }
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
