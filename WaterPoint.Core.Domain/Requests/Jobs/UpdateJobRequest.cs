using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class UpdateJobRequest : IRequest
    {
        public OrgEntityRp Parameter { get; set; }
        public Delta<WriteJobPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
