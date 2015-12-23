using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.JobTasks;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobTasks
{
    public class UpdateJobTaskRequest : IRequest
    {
        public OrgEntityJobId Parameter { get; set; }
        public Delta<WriteJobTaskPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
