namespace WaterPoint.Core.Domain.RequestParameters
{
    public class OrgIdJobIdIdRp : IRequest
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }

        public int Id { get; set; }
    }
}
