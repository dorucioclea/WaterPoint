using WaterPoint.Core.Domain.RequestParameters.Interfaces;

namespace WaterPoint.Core.Domain.RequestParameters
{
    public class OrgEntityRp : IOrgEntity
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
