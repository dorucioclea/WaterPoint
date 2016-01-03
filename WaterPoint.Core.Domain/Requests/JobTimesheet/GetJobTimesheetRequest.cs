using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobTimesheet
{
    public class GetJobTimesheetRequest : IRequest
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }

        public int Id { get; set; }
    }
}
