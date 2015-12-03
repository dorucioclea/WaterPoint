using System.Web.Http.OData;
using WaterPoint.Core.Domain.Dtos.Interfaces;
using WaterPoint.Core.Domain.Dtos.Payloads.JobTasks;

namespace WaterPoint.Core.Domain.Dtos.Requests.JobTasks
{
    public class UpdateJobTaskRequest : IOrganizationEntityParameter, IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
        public Delta<WriteJobTaskPayload> UpdateJobTaskPayload { get; set; }
        public int StaffId { get; set; }
    }
}
