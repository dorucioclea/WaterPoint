using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Addresses
{
    public class CreateAddress : IQueryParameter
    {
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
