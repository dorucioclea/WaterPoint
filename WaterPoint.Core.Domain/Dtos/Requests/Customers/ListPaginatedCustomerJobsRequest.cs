using WaterPoint.Core.Domain.Dtos.Parameters;

namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class ListPaginatedCustomerJobsRequest : IRequest
    {
        public CustomerIdOrgIdParameter CustomerIdOrgIdParameter { get; set; }
        public PaginationParamter PaginationParamter { get; set; }
    }
}
