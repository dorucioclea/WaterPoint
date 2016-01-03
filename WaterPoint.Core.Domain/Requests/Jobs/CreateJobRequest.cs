using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class CreateJobRequest : IRequest, IOrgId
    {
        public WriteJobPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
        public int OrganizationId { get; set; }
    }
}
