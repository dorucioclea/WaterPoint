using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters
{
    public class GetOrganizationEntity : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
