using WaterPoint.Core.Domain;

namespace WaterPoint.Core.Bll.QueryParameters.Credentials
{
    public class GetAuthClientQueryParameter : IQueryParameter
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public bool IsInternal { get; set; }
    }
}
