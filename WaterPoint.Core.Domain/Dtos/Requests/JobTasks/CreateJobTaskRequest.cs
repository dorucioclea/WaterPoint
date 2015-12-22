using WaterPoint.Core.Domain.Dtos.Payloads.JobTasks;

namespace WaterPoint.Core.Domain.Dtos.Requests.JobTasks
{
    public class CreateJobTaskRequest : IRequest
    {
        public OrgIdParameter OrganizationId { get; set; }
        public WriteJobTaskPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
