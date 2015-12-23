using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Customers
{
    public class GetCustomer : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
    }
}
