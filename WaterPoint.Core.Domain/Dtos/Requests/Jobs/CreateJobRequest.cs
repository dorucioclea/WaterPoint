using WaterPoint.Core.Domain.Dtos.Payloads.Jobs;

namespace WaterPoint.Core.Domain.Dtos.Requests.Jobs
{
    public class CreateJobRequest : IRequest
    {
        public OrgIdRp OrganizationIdParameter { get; set; }
        public WriteBasicJobDataPayload CreateJobPayload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
