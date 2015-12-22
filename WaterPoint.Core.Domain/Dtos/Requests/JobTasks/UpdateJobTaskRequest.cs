using System.Web.Http.OData;
using WaterPoint.Core.Domain.Dtos.Payloads.JobTasks;

namespace WaterPoint.Core.Domain.Dtos.Requests.JobTasks
{
    public class UpdateJobTaskRequest : IRequest
    {
        public OrgEntityJobId Parameter { get; set; }
        public Delta<WriteJobTaskPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
