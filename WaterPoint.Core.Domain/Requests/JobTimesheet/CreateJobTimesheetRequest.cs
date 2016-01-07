using WaterPoint.Core.Domain.Payloads.JobTimesheet;

namespace WaterPoint.Core.Domain.Requests.JobTimesheet
{
    public class CreateJobTimesheetRequest : ICreateRequest<WriteJobTimesheetPayload>
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }

        public int Id { get; set; }

        public WriteJobTimesheetPayload Payload { get; set; }
    }
}
