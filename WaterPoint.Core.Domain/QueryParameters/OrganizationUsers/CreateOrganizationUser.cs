using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.OrganizationUsers
{
    public class CreateOrganizationUser : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int CredentialId { get; set; }
        public int OrganizationUserTypeId { get; set; }
    }
}
