using WaterPoint.Core.Domain.Dtos.Payloads.Jobs;

namespace WaterPoint.Core.Domain.Dtos.Requests.Jobs
{
    public class CreateJobRequest : IRequest
    {
        public OrganizationIdParameter OrganizationIdParameter { get; set; }
        public WriteJobPayload CreateJobPayload { get; set; }
        public int StaffId { get; set; }
    }
}
