using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.TaskDefinitions;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.TaskDefinitions
{
    public class UpdateTaskDefinitionRequest : IRequest
    {
        public OrgEntityRp Parameter { get; set; }
        public Delta<WriteTaskDefinitionPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
