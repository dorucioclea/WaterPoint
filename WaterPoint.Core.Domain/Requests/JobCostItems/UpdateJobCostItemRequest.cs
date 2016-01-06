using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.JobCostItems;

namespace WaterPoint.Core.Domain.Requests.JobCostItems
{
    public class UpdateJobCostItemRequest : IUpdateRequest<WriteJobCostItemPayload>
    {
        public int JobId { get; set; }
        public int OrganizationId { get; set; }
        public int Id { get; set; }
        public Delta<WriteJobCostItemPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
