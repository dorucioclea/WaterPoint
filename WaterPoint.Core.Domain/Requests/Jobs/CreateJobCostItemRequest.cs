using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class CreateJobCostItemRequest : IRequest
    {
        public JobIdOrgIdRp Parameter { get; set; }

        public WriteJobCostItemPayload Payload { get; set; }

        public int OrganizationUserId { get; set; }
    }
}
