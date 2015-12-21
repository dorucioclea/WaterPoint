namespace WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions
{
    public class GetTaskDefinitionByIdRequest: IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
    }
}
