using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Suppliers
{
    public class CreateSupplier : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }
    }
}
