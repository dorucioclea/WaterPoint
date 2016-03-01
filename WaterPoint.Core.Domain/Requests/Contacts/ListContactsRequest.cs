using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Contacts
{
    public class ListContactsRequest : IPaginationRequest
    {
        public int OrganizationId { get; set; }
        public bool? IsDeleted { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string Sort { get; set; }
        public bool? IsDesc { get; set; }
        public string SearchTerm { get; set; }
    }
}
