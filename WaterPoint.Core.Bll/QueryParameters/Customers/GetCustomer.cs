using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Bll.QueryParameters.Customers
{
    public class GetCustomer : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
    }
}
