using WaterPoint.Core.Domain;

namespace WaterPoint.Core.Bll.QueryParameters.Jobs
{
    public class GetJobDetailsQueryParameter : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
    }
}
