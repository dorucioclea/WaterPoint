using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.Jobs;

namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class UpdateJobRequest : IUpdateRequest<WriteJobPayload>
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
        public Delta<WriteJobPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
