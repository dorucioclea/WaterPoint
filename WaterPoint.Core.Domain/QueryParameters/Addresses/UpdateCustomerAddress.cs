using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Domain.QueryParameters.Addresses
{
    public class UpdateCustomerAddress : IQueryParameter
    {
        [IgnoreWhenUpdate]
        public int AddressId { get; set; }

        [IgnoreWhenUpdate]
        public int CustomerId { get; set; }

        [IgnoreWhenUpdate]
        public int OrganizationId { get; set; }

        public bool IsPrimary { get; set; }

        public bool IsPostAddress { get; set; }
    }
}