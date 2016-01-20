using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Domain.QueryParameters.OrganizationUsers
{
    public class EnterOrganization : IQueryParameter
    {
        [IgnoreWhenUpdate]
        public int OrganizationId { get; set; }

        [IgnoreWhenUpdate]
        public int OrganizationUserId { get; set; }

        public bool IsSignedIn { get; set; }
    }
}
