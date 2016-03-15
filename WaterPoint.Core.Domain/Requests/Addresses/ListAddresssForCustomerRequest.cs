namespace WaterPoint.Core.Domain.Requests.Addresses
{
    public class ListCustomerAddressesRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
