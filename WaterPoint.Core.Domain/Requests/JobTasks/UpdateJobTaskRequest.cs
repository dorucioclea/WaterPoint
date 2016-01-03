using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.JobTasks;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobTasks
{
    public class UpdateJobTaskRequest : IRequest
    {
        public int JobId { get; set; }
        public int OrganizationId { get; set; }
        public int Id { get; set; }
        public Delta<UpdateJobTaskPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
