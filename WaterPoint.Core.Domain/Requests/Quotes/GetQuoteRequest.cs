using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Quotes
{
    public class GetQuoteRequest : IRequest, IOrgEntity
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
