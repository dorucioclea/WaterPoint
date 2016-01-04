using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.QuoteTasks;

namespace WaterPoint.Core.Domain.Requests.QuoteTasks
{
    public class UpdateQuoteTaskRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int QuoteId { get; set; }
        public int Id { get; set; }
        public Delta<UpdateQuoteTaskPayload> Payload { get; set; }
    }
}
