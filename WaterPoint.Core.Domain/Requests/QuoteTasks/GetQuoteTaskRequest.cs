using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.QuoteTasks
{
    public class GetQuoteTaskRequest : IRequest, IOrgEntity
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
        public int QuoteId { get; set; }
    }
}
