namespace WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions
{
    public class GetTaskDefinitionByIdRequest: IRequest
    {
        public OrgEntityRp OrganizationEntityParameter { get; set; }
    }
}
