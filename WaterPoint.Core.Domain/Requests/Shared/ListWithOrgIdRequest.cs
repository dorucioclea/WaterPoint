using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Shared
{
    public class ListWithOrgIdRequest : IRequest
    {
        public OrgIdRp OrganizationIdParameter { get; set; }
        public PaginationRp PaginationParamter { get; set; }
    }
}
