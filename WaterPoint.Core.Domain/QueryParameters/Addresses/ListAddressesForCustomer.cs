using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Addresses
{
    public class ListAddressesForCustomer : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
