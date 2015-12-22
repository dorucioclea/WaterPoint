using System;
using Microsoft.Build.Framework;

namespace WaterPoint.Core.Domain.Dtos.Payloads.Jobs
{
    public class WriteBasicJobDataPayload
    {
        [Required]
        public int? JobStatusId { get; set; }

        public string Code { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public int? CustomerId { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }
    }
}
