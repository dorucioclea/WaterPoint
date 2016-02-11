namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class SearchTop10CustomerRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public string SearchTerm { get; set; }
    }
}
