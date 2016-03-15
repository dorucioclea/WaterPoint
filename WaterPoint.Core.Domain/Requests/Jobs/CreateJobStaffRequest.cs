using WaterPoint.Core.Domain.Payloads.Jobs;

namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class CreateJobStaffRequest : ICreateRequest<CreateJobStaffPayload>
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
        public CreateJobStaffPayload Payload { get; set; }
    }
}
