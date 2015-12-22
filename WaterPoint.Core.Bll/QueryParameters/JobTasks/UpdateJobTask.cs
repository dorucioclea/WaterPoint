using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Bll.QueryParameters.JobTasks
{
    public class UpdateJobTask : IQueryParameter
    {
        [IgnoreWhenUpdate]
        public int Id { get; set; }

        [IgnoreWhenUpdate]
        public int JobId { get; set; }

        [IgnoreWhenUpdate]
        public int TaskDefinitionId { get; set; }

        public int DisplayOrder { get; set; }

        public int? EstimatedTimeInMinutes { get; set; }

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
