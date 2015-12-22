using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Bll.QueryParameters.TaskDefinitions
{
    public class CreateTaskDefinition : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }
    }
}
