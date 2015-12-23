namespace WaterPoint.Core.Domain.RequestParameters
{
    public class JobIdOrgIdRp : IRequest
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }
    }
}
