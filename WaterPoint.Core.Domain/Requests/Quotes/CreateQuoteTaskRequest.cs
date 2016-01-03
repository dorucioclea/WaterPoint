using WaterPoint.Core.Domain.Payloads.Quotes;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Quotes
{
    public class CreateQuoteTaskRequest : IRequest
    {
        public int OrganizationId { get; set; }

        public int CustomerId { get; set; }

        public int QuoteId { get; set; }

        public CreateQuoteTaskPayload Payload { get; set; }
    }
}
