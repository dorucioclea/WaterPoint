using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Domain.QueryParameters.OrganizationUsers
{
    public class SignInManagement : IQueryParameter
    {
        [IgnoreWhenUpdate]
        public int OrganizationId { get; set; }

        [IgnoreWhenUpdate]
        public int OrganizationUserId { get; set; }

        [IgnoreWhenUpdate]
        public int CredentialId { get; set; }

        public bool IsSignedIn { get; set; }
    }
}
