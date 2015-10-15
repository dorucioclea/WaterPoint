namespace WaterPoint.Core.Domain.Requests.Products
{
    public class ListProductsByFlagRequest : IUriPathRequest
    {
        public int FlagId { get; set; }
        public int OrganizationId { get; set; }
    }
}
