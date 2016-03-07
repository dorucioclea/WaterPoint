using System.Collections.Generic;

namespace WaterPoint.Core.Domain.Payloads.Jobs
{
    public class CreateJobStaffPayload : IPayload
    {
        public IEnumerable<int> StaffIds { get; set; }
    }
}
