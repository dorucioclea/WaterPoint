namespace WaterPoint.Core.Domain.Requests.Addresses
{
    public class GetCustomerAddressRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public bool? IsDeleted { get; set; }
        public int Id { get; set; }
    }
}
