using WaterPoint.Core.Domain.Dtos.Payloads.JobTasks;

namespace WaterPoint.Core.Domain.Dtos.Requests.JobTasks
{
    public class CreateJobTaskRequest : IRequest
    {
        public OrgIdParameter OrganizationIdParameter { get; set; }
        public WriteJobTaskPayload CreateJobTaskPayload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
