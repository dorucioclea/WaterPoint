using System;
using Microsoft.Build.Framework;

namespace WaterPoint.Core.Domain.Payloads.Jobs
{
    public class WriteJobPayload
    {
        [Required]
        public int? JobStatusId { get; set; }

        public int? PriorityTypeId { get; set; }

        public int? JobCategoryId { get; set; }

        public string Code { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        [Required]
        public int? CustomerId { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal? Budget { get; set; }

        public decimal? ExcludeFromWip { get; set; }
    }
}
