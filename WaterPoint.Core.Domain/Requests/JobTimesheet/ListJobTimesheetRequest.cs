using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobTimesheet
{
    public class ListJobTimesheetRequest : IRequest
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }
    }
}
