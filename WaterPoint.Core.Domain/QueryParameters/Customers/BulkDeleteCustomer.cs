using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Customers
{
    public class BulkDeleteCustomer : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public string Customers { get; set; }
    }
}
