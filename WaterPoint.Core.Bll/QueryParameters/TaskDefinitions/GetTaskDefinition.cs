using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Bll.QueryParameters.TaskDefinitions
{
    public class GetTaskDefinition : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int TaskDefinitionId { get; set; }
    }
}
