using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Domain.QueryParameters.Addresses
{
    public class UpdateAddress : IQueryParameter
    {
        [IgnoreWhenUpdate]
        public int Id { get; set; }

        [IgnoreWhenUpdate]
        public int OrganizationId { get; set; }

        public string Street { get; set; }

        public string StreetExtraLine { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostCode { get; set; }

        public int CountryId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
