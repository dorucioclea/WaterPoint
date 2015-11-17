namespace WaterPoint.Core.Domain.Requests
{
    public class OrganizationEntityRequest : IUriPathRequest
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
