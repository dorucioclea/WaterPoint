namespace WaterPoint.Core.Domain.Requests.Contacts
{
    public class ListCustomerContactsRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
