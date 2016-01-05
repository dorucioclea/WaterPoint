using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.QuoteCostItems;

namespace WaterPoint.Core.Domain.Requests.QuoteCostItems
{
    public class UpdateQuoteCostItemRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int QuoteId { get; set; }
        public int Id { get; set; }
        public Delta<UpdateQuoteCostItemPayload> Payload { get; set; }
    }
}
