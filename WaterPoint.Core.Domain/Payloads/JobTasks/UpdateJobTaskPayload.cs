using System;
using System.ComponentModel.DataAnnotations;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Domain.Payloads.JobTasks
{
    public class UpdateJobTaskPayload
    {
        public int? DisplayOrder { get; set; }

        public int? EstimatedTimeInMinutes { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [Required]
        public bool? IsBillable { get; set; }

        [MaxLength(200)]
        public string ShortDescription { get; set; }

        [MaxLength(2000)]
        public string LongDescription { get; set; }
    }
}
