using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Staff
{
    public class GetStaff : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }

    public class GetStaffByLogin : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public string Email { get; set; }
    }
}
