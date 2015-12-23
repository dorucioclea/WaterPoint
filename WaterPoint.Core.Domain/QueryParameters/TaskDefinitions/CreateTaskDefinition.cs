using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.TaskDefinitions
{
    public class CreateTaskDefinition : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }
    }
}
