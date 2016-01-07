using WaterPoint.Core.Domain.Payloads.Quotes;

namespace WaterPoint.Core.Domain.Requests.Quotes
{
    public class CreateQuoteRequest : ICreateRequest<CreateQuotePayload>
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public CreateQuotePayload Payload { get; set; }
    }
}
