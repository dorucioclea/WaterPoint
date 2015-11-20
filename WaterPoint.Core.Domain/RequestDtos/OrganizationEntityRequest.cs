namespace WaterPoint.Core.Domain.RequestDtos
{
    public class OrganizationEntityRequest : IUriPathRequest
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
