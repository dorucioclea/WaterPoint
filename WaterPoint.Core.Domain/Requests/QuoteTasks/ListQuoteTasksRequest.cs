using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.QuoteTasks
{
    public class ListQuoteTasksRequest : IRequest, ISimplePagination
    {
        public int QuoteId { get; set; }
        public int OrganizationId { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
