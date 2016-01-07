using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.JobTimesheet;

namespace WaterPoint.Core.Domain.Requests.JobTimesheet
{
    public class UpdateJobTimesheetRequest : IUpdateRequest<WriteJobTimesheetPayload>
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }

        public int Id { get; set; }

        public Delta<WriteJobTimesheetPayload> Payload { get; set; }
    }
}
