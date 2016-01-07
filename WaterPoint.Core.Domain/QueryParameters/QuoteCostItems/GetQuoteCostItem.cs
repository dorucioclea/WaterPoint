using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.QuoteCostItems
{
    public class GetQuoteCostItem : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int QuoteId { get; set; }
        public int Id { get; set; }
    }
}
