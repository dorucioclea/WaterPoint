namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class SearchCustomerByNameRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public string SearchTerm { get; set; }
    }
}
