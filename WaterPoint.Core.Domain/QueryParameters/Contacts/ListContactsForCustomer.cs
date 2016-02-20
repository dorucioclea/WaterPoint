using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Contacts
{
    public class ListContactsForCustomer : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
    }
}
