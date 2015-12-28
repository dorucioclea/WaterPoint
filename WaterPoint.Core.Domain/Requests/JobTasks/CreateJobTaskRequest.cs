using WaterPoint.Core.Domain.Payloads.JobTasks;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobTasks
{
    public class CreateJobTaskRequest : IRequest
    {
        public OrgIdJobIdRp Parameter { get; set; }
        public CreateJobTaskPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
