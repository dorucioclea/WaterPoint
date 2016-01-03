using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.TaskDefinitions;

namespace WaterPoint.Core.Domain.Requests.TaskDefinitions
{
    public class UpdateTaskDefinitionRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
        public Delta<WriteTaskDefinitionPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
