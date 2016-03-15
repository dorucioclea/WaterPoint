using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters
{
    public class ToggleIsDelete : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public bool IsDelete { get; set; }

        public int Id { get; set; }
    }
}
