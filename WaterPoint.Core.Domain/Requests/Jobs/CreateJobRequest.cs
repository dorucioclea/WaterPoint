using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class CreateJobRequest : ICreateRequest<WriteJobPayload>, IOrgId
    {
        public WriteJobPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
        public int OrganizationId { get; set; }
    }
}
