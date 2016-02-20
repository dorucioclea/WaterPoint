using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Contacts
{
    public class CreateCustomerContact : IQueryParameter
    {
        public int CustomerId { get; set; }
        public int ContactId { get; set; }
        public bool IsPrimary { get; set; }
    }
}