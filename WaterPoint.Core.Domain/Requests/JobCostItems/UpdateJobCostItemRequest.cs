using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.JobCostItems;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobCostItems
{
    public class UpdateJobCostItemRequest : IRequest
    {
        public OrgEntityJobId Parameter { get; set; }
        public Delta<WriteJobCostItemPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
