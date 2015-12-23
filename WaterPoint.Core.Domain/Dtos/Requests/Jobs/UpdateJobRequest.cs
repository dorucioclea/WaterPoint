using System.Web.Http.OData;
using WaterPoint.Core.Domain.Dtos.Payloads.Jobs;

namespace WaterPoint.Core.Domain.Dtos.Requests.Jobs
{
    public class UpdateJobRequest : IRequest
    {
        public OrgEntityRp Parameter { get; set; }
        public Delta<WriteJobPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
