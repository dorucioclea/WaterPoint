using WaterPoint.Core.Domain.RequestParameters.Interfaces;

namespace WaterPoint.Core.Domain.RequestParameters
{
    public class ListCustomerRp : IOrgId, IPagination
    {
        public int OrganizationId { get; set; }
        public bool? IsProspect { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string Sort { get; set; }
        public bool? IsDesc { get; set; }
        public string SearchTerm { get; set; }
    }
}
