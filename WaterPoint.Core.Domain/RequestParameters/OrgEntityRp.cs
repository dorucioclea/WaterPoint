namespace WaterPoint.Core.Domain.RequestParameters
{
    public class OrgEntityRp : IUriPathParameter
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }

    public class OrgEntityJobId : OrgEntityRp, IRequest
    {
        public int JobId { get; set; }
    }
}
