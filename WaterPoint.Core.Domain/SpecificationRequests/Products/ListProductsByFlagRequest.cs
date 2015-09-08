namespace WaterPoint.Core.Domain.SpecificationRequests.Products
{
    public class ListProductsByFlagRequest : ISpecificationRequest
    {
        public int FlagId { get; set; }
        public int ShopId { get; set; }
    }
}
