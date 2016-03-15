using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.Jobs
{
    public class CreateJobStaffPayload : IPayload
    {
        [Required]
        public IEnumerable<int> StaffIds { get; set; }
    }
}
