namespace WaterPoint.Core.Domain.Requests.Contacts
{
    public class GetContactRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
