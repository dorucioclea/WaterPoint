using WaterPoint.Core.Domain.Dtos.Payloads.TaskDefinitions;

namespace WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions
{
    public class CreateTaskDefinitionRequest : IRequest
    {
        public OrgIdParameter OrganizationId { get; set; }
        public WriteTaskDefinitionPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
