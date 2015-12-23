using WaterPoint.Core.Domain.Dtos.RequestParameters;

namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class ListCustomersRequest : IRequest
    {
        public IsProspectOrgIdRp IsProspectOrgId { get; set; }

        public PaginationRp Pagination { get; set; }
    }
}
