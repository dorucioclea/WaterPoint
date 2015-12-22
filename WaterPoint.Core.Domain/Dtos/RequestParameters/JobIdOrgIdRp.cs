namespace WaterPoint.Core.Domain.Dtos.RequestParameters
{
    public class JobIdOrgIdRp : IRequest
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }
    }
}
