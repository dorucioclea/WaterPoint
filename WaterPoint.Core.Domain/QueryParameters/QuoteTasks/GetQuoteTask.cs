using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.QuoteTasks
{
    public class GetQuoteTask : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int QuoteId { get; set; }
        public int Id { get; set; }
    }
}
