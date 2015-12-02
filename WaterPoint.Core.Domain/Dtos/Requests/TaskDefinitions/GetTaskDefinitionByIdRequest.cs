using WaterPoint.Core.Domain.Dtos.Interfaces;

namespace WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions
{
    public class GetTaskDefinitionByIdRequest: IOrganizationEntityParameter, IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
    }
}
