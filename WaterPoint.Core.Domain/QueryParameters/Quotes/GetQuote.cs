using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Quotes
{
    public class GetQuote : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
