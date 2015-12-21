using WaterPoint.Core.Domain.Dtos.RequestParameters;

namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class ListCustomersRequest : IRequest
    {
        public IsProspectOrgIdParameter IsProspectOrgId { get; set; }

        public PaginationParamter Pagination { get; set; }
    }
}
