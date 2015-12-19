using WaterPoint.Core.Domain.Dtos.Payloads.TaskDefinitions;

namespace WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions
{
    public class CreateTaskDefinitionRequest : IRequest
    {
        public OrganizationIdParameter OrganizationIdParameter { get; set; }
        public WriteTaskDefinitionPayload CreateTaskDefinitionPayload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
