using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class ListCustomersRequest : IRequest
    {
        public IsProspectOrgIdRp IsProspectOrgId { get; set; }

        public PaginationRp Pagination { get; set; }
    }
}
