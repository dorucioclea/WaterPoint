using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class CreateJobRequest : IRequest
    {
        public OrgIdRp OrganizationIdParameter { get; set; }
        public WriteJobPayload CreateJobPayload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
