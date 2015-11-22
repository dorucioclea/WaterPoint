namespace WaterPoint.Core.Domain.Dtos.Customers.Requests
{
    public class PaginationWithOrgIdRequest : IRequest
    {
        public OrganizationIdParameter OrganizationIdParameter { get; set; }
        public PaginationParamter PaginationParamter { get; set; }
    }
}
