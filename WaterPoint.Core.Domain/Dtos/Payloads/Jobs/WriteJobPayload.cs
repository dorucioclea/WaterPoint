using System;
using Microsoft.Build.Framework;

namespace WaterPoint.Core.Domain.Dtos.Payloads.Jobs
{
    public class WriteJobPayload
    {
        [Required]
        public int JobStatusId { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? UpdatedByStaffId { get; set; }
    }
}
