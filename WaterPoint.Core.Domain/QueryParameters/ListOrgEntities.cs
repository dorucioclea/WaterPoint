using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters
{
    public class ListOrgEntities : IQueryParameter
    {
        public int OrganizationId { get; set; }
    }
}
