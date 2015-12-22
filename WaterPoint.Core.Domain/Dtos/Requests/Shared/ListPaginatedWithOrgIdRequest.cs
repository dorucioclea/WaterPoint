using WaterPoint.Core.Domain.Dtos.RequestParameters;

namespace WaterPoint.Core.Domain.Dtos.Requests.Shared
{
    public class ListPaginatedWithOrgIdRequest : IRequest
    {
        public OrgIdParameter OrganizationIdParameter { get; set; }
        public PaginationParamter PaginationParamter { get; set; }
    }
}
