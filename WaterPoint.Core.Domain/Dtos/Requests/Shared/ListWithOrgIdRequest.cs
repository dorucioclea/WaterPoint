using WaterPoint.Core.Domain.Dtos.RequestParameters;

namespace WaterPoint.Core.Domain.Dtos.Requests.Shared
{
    public class ListWithOrgIdRequest : IRequest
    {
        public OrgIdRp OrganizationIdParameter { get; set; }
        public PaginationRp PaginationParamter { get; set; }
    }
}
