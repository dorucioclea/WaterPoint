using WaterPoint.Core.Domain.Payloads.JobCostItems;

namespace WaterPoint.Core.Domain.Requests.JobCostItems
{
    public class CreateJobCostItemRequest : ICreateRequest<WriteJobCostItemPayload>
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }

        public WriteJobCostItemPayload Payload { get; set; }

        public int OrganizationUserId { get; set; }
    }
}
