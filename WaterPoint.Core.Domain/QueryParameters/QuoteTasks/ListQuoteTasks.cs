using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.QuoteTasks
{
    public class ListQuoteTasks : ISimplePagedQueryParameter
    {
        public int OrganizationId { get; set; }
        public int QuoteId { get; set; }
        public int Offset { get; set; }
        public int PageSize { get; set; }
    }
}
