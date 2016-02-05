using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Credentials
{
    public class UndeleteStaffByLoginEmail : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public string LoginEmail { get; set; }
    }
}
