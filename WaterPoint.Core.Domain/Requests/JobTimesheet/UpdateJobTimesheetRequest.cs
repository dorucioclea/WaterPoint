using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.JobTimesheet;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobTimesheet
{
    public class UpdateJobTimesheetRequest : IRequest
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }

        public int Id { get; set; }

        public Delta<WriteJobTimesheetPayload> Payload { get; set; }
    }
}
