using WaterPoint.Core.Domain.Payloads.Customers;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobTimesheet
{
    public class CreateJobTimesheetRequest : IRequest
    {
        public OrgIdJobIdIdRp Parameter { get; set; }
        public WriteJobTimesheetPayload Payload { get; set; }
    }
}
