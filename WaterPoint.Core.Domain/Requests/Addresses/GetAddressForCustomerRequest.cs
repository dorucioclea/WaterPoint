namespace WaterPoint.Core.Domain.Requests.Addresses
{
    public class GetAddressForCustomerRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public int Id { get; set; }
    }
}
