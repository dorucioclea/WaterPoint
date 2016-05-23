using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.Jobs
{
    public class CreateJobStaffPayload : IPayload
    {
        [Required]
        public int StaffId { get; set; }
    }
}
