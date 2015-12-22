using System;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Bll.QueryParameters.JobTasks
{
    public class CreateJobTask : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }

        public int TaskDefinitionId { get; set; }

        public int DisplayOrder { get; set; }

        public int EstimatedTimeInMinutes { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public bool IsBillable { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsAllocated { get; set; }

        public bool IsScheduled { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }
    }
}
