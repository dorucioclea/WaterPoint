namespace WaterPoint.Core.Domain.Requests.Addresses
{
    public class ListAddressesForCustomerRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
