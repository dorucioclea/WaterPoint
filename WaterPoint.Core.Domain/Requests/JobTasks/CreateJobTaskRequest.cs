using WaterPoint.Core.Domain.Payloads.JobTasks;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobTasks
{
    public class CreateJobTaskRequest : IRequest
    {
        public JobIdOrgIdRp Parameter { get; set; }
        public WriteJobTaskPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
