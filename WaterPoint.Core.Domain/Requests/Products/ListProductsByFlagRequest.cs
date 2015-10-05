namespace WaterPoint.Core.Domain.Requests.Products
{
    public class ListProductsByFlagRequest : IRequest
    {
        public int FlagId { get; set; }
        public int OrganizationId { get; set; }
    }
}
