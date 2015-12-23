using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class ListCustomerJobsRequest : IRequest
    {
        public CustomerIdOrgIdRp CustomerIdOrgIdRp { get; set; }
        public PaginationRp PaginationParamter { get; set; }
    }
}
