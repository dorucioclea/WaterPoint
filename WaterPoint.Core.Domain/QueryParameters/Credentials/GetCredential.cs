using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Credentials
{
    public class GetCredential : IQueryParameter
    {
        public string Email { get; set; }
    }
}
