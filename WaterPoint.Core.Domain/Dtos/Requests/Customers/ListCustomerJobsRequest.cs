using WaterPoint.Core.Domain.Dtos.RequestParameters;

namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class ListCustomerJobsRequest : IRequest
    {
        public CustomerIdOrgIdRp CustomerIdOrgIdRp { get; set; }
        public PaginationRp PaginationParamter { get; set; }
    }
}
