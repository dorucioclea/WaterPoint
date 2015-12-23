using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Credentials
{
    public class GetAuthClient : IQueryParameter
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public bool IsInternal { get; set; }
    }
}
