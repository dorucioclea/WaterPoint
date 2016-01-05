using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Customers
{
    public class ListCustomerJobs : ISimplePagedQueryParameter
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public int Offset { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
