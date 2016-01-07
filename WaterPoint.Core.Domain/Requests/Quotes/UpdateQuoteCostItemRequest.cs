using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.Quotes;

namespace WaterPoint.Core.Domain.Requests.Quotes
{
    public class UpdateQuoteRequest : IUpdateRequest<UpdateQuotePayload>
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
        public Delta<UpdateQuotePayload> Payload { get; set; }
    }
}
