namespace WaterPoint.Core.Domain.Dtos.RequestParameters
{
    public class IsProspectOrgIdParameter : IUriPathParameter
    {
        public int OrganizationId { get; set; }
        public bool? IsProspect { get; set; }
    }
}
