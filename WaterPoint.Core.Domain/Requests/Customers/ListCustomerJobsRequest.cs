using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class ListCustomerJobsRequest : IRequest
    {
        public OrgIdCusIdRp Parameter { get; set; }
        public PaginationRp Pagination { get; set; }
    }
}
