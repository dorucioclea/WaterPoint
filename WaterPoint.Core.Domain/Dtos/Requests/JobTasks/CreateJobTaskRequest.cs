using WaterPoint.Core.Domain.Dtos.Payloads.JobTasks;
using WaterPoint.Core.Domain.Dtos.RequestParameters;

namespace WaterPoint.Core.Domain.Dtos.Requests.JobTasks
{
    public class CreateJobTaskRequest : IRequest
    {
        public JobIdOrgIdRp Parameter { get; set; }
        public WriteJobTaskPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
