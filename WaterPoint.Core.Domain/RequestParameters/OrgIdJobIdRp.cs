using WaterPoint.Core.Domain.RequestParameters.Interfaces;

namespace WaterPoint.Core.Domain.RequestParameters
{
    public class OrgIdJobIdRp : IOrgId, IRequest
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }
    }
}
