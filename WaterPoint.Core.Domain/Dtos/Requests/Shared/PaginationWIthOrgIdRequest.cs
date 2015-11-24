namespace WaterPoint.Core.Domain.Dtos.Requests.Shared
{
    public class PaginationWithOrgIdRequest : IRequest
    {
        public OrganizationIdParameter OrganizationIdParameter { get; set; }
        public PaginationParamter PaginationParamter { get; set; }
    }
}
