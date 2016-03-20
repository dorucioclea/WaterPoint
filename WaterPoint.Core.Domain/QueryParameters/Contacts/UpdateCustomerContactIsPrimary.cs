using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Contacts
{
    public class UpdateCustomerContactIsPrimary : IQueryParameter
    {
        public int CustomerId { get; set; }
        public int OrganizationId { get; set; }
        public bool IsPrimary { get; set; }
        public int ContactId { get; set; }
    }
}
