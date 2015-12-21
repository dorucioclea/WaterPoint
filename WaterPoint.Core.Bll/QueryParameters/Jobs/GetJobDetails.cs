using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Bll.QueryParameters.Jobs
{
    public class GetJobDetails : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
    }
}
