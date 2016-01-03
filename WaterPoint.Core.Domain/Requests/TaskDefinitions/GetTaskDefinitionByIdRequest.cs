namespace WaterPoint.Core.Domain.Requests.TaskDefinitions
{
    public class GetTaskDefinitionByIdRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
