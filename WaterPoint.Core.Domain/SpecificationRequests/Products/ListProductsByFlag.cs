namespace WaterPoint.Core.Domain.SpecificationRequests.Products
{
    public class ListProductsByFlag : ISpecificationRequest
    {
        public int FlagId { get; set; }
        public int ShopId { get; set; }
    }
}
