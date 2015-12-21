using System.Web.Http.OData;
using WaterPoint.Core.Domain.Dtos.Payloads.TaskDefinitions;

namespace WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions
{
    public class UpdateTaskDefinitionRequest : IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
        public Delta<WriteTaskDefinitionPayload> UpdateTaskDefinitionPayload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
