using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Jobs
{
    public class DeleteJobStaff : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int StaffId { get; set; }
        public int JobId { get; set; }
    }
}
