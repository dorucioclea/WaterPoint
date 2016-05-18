using System.Collections.Generic;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Jobs
{
    public class CreateJobStaff : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
        public int StaffId { get; set; }
    }
}
