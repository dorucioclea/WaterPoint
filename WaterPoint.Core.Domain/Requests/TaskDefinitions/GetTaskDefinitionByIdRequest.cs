using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.TaskDefinitions
{
    public class GetTaskDefinitionByIdRequest: IRequest
    {
        public OrgEntityRp OrganizationEntityParameter { get; set; }
    }
}
