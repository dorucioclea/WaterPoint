using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.TaskDefinitions
{
    public class GetTaskDefinition : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int TaskDefinitionId { get; set; }
    }
}
