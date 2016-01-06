using WaterPoint.Core.Domain.Payloads.QuoteTasks;

namespace WaterPoint.Core.Domain.Requests.QuoteTasks
{
    public class CreateQuoteTaskRequest : ICreateRequest<CreateQuoteTaskPayload>
    {
        public int OrganizationId { get; set; }

        public int CustomerId { get; set; }

        public int QuoteId { get; set; }

        public CreateQuoteTaskPayload Payload { get; set; }
    }
}
