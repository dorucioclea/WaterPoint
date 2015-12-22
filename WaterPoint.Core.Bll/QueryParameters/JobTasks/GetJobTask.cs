using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Bll.QueryParameters.JobTasks
{
    public class GetJobTask : IQueryParameter
    {
        public int JobTaskId { get; set; }
    }
}
