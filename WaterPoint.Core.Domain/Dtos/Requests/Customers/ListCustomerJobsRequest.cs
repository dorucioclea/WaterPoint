using WaterPoint.Core.Domain.Dtos.RequestParameters;

namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class ListCustomerJobsRequest : IRequest
    {
        public CustomerIdOrgIdParameter CustomerIdOrgIdParameter { get; set; }
        public PaginationParamter PaginationParamter { get; set; }
    }
}
