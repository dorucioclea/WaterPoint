namespace WaterPoint.Core.Domain.Dtos
{
    public class OrganizationEntityParameter : IUriPathParameter
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
