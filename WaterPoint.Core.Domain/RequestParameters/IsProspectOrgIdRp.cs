namespace WaterPoint.Core.Domain.RequestParameters
{
    public class IsProspectOrgIdRp : IUriPathParameter
    {
        public int OrganizationId { get; set; }
        public bool? IsProspect { get; set; }
    }
}
