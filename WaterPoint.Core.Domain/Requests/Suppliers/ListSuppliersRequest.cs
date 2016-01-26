using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Suppliers
{
    public class ListSuppliersRequest : IOrgId, IPaginationRequest
    {
        public int OrganizationId { get; set; }
        public bool? IsActive { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string Sort { get; set; }
        public bool? IsDesc { get; set; }
        public string SearchTerm { get; set; }
    }
}
