using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Suppliers
{
    public class ListSuppliers : IPagedQueryParameter
    {
        public int OrganizationId { get; set; }
        public int Offset { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }
        public bool IsDesc { get; set; }
        public string SearchTerm { get; set; }
        public bool? IsActive { get; set; }
        public int PageNumber { get; set; }
    }
}
