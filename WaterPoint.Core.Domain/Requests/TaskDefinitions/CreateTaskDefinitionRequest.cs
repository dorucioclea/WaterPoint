using WaterPoint.Core.Domain.Payloads.TaskDefinitions;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.TaskDefinitions
{
    public class CreateTaskDefinitionRequest : IRequest
    {
        public OrgIdRp OrganizationId { get; set; }
        public WriteTaskDefinitionPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
