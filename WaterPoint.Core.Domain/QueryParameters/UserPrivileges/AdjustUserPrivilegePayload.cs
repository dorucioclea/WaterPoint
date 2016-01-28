using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.UserPrivileges
{
    public class AdjustUserPrivilege : IQueryParameter
    {
        public int OrganizationUserId { get; set; }
        public int OrganizationId { get; set; }
        public string PrivilegeIds { get; set; }
    }
}
