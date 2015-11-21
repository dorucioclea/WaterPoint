namespace WaterPoint.Core.Domain.RequestDtos
{
    public class OrganizationEntityParameter : IUriPathParameter
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
