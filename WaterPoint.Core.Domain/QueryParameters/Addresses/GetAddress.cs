using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Addresses
{
    public class GetAddress : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
