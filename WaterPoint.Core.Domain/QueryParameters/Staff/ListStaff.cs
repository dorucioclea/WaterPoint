using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Staff
{
    public class ListStaff : IQueryParameter
    {
        public int OrganizationId { get; set; }
    }
}
