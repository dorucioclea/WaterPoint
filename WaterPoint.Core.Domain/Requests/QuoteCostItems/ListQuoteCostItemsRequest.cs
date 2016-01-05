using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.QuoteCostItems
{
    public class ListQuoteCostItemsRequest : ISimplePagination
    {
        public int OrganizationId { get; set; }
        public int QuoteId { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
