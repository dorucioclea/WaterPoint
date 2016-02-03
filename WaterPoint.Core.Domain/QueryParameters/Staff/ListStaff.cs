using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Staff
{
    public class ListStaff : ISimplePagedQueryParameter
    {
        public int OrganizationId { get; set; }
        public int Offset { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool? IsWorking { get; set; }
        public bool IsDeleted => false;
    }
}
