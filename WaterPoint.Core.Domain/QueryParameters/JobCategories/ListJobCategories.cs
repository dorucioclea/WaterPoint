using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.JobCategories
{
    public class ListJobCategories : IQueryParameter
    {
        public int OrganizationId { get; set; }
    }
}
