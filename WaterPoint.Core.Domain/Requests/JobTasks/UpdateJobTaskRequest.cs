using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.JobTasks;

namespace WaterPoint.Core.Domain.Requests.JobTasks
{
    public class UpdateJobTaskRequest : IUpdateRequest<UpdateJobTaskPayload>
    {
        public int JobId { get; set; }
        public int OrganizationId { get; set; }
        public int Id { get; set; }
        public Delta<UpdateJobTaskPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
