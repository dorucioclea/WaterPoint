using WaterPoint.Core.Domain.RequestParameters.Interfaces;

namespace WaterPoint.Core.Domain.RequestParameters
{
    public class OrgEntityJobId : IOrgEntity, IRequest
    {
        public int JobId { get; set; }
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
