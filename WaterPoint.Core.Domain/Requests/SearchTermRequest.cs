namespace WaterPoint.Core.Domain.Requests
{
    public class SearchTermRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public string SearchTerm { get; set; }
    }
}
