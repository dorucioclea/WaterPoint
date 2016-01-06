using WaterPoint.Core.Domain.Payloads.JobTasks;

namespace WaterPoint.Core.Domain.Requests.JobTasks
{
    public class CreateJobTaskRequest : ICreateRequest<CreateJobTaskPayload>
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
        public CreateJobTaskPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
