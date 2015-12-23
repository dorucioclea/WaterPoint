using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Bll.QueryParameters.JobTasks
{
    public class GetJobTask : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int JobTaskId { get; set; }
        public int JobId { get; set; }
    }
}
