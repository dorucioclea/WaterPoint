using WaterPoint.Core.Domain;

namespace WaterPoint.Core.Bll.QueryParameters.Customers
{
    public class GetCustomerQueryParameter : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
    }
}
