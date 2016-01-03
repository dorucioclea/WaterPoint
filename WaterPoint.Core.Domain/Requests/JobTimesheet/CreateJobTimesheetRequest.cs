using WaterPoint.Core.Domain.Payloads.JobTimesheet;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobTimesheet
{
    public class CreateJobTimesheetRequest : IRequest
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }

        public int Id { get; set; }

        public WriteJobTimesheetPayload Payload { get; set; }
    }
}
