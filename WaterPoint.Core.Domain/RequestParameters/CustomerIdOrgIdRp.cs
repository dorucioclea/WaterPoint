using WaterPoint.Core.Domain.RequestParameters.Interfaces;

namespace WaterPoint.Core.Domain.RequestParameters
{
    public class CustomerIdOrgIdRp : IOrgId
    {
        public int OrganizationId { get; set; }

        public int CustomerId { get; set; }
    }
}
