using System;
using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Dtos.Payloads.JobTasks
{
    public class WriteJobTaskPayload
    {
        [Required]
        public int? JobId { get; set; }

        [Required]
        public int? TaskDefinitionId { get; set; }

        public int? DisplayOrder { get; set; }

        public int? EstimatedTimeInMinutes { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [Required]
        public bool? IsBillable { get; set; }

        [MaxLength(100)]
        public string ShortDescription { get; set; }

        [MaxLength(2000)]
        public string LongDescription { get; set; }
    }
}
