using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Addresses
{
    public class CreateCustomerAddress : IQueryParameter
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsPostAddress { get; set; }
    }
}
