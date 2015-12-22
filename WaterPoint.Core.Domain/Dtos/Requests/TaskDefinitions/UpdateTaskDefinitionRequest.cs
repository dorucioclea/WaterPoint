using System.Web.Http.OData;
using WaterPoint.Core.Domain.Dtos.Payloads.TaskDefinitions;

namespace WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions
{
    public class UpdateTaskDefinitionRequest : IRequest
    {
        public OrganizationEntityParameter Parameter { get; set; }
        public Delta<WriteTaskDefinitionPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
