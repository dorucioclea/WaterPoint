using WaterPoint.Core.Domain.RequestParameters.Interfaces;

namespace WaterPoint.Core.Domain.RequestParameters
{
    public class IsProspectOrgIdRp : IOrgId
    {
        public int OrganizationId { get; set; }
        public bool? IsProspect { get; set; }
    }
}
