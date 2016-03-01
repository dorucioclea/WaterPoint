using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Contacts
{
    public class ListContacts : IPagedQueryParameter
    {
        public int OrganizationId { get; set; }
        public bool IsDeleted { get; set; }
        public int Offset { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Sort { get; set; }
        public bool IsDesc { get; set; }
        public string SearchTerm { get; set; }
    }
}
