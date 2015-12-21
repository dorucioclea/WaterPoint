using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Bll.QueryParameters.Credentials
{
    public class ListCredentials : IQueryParameter
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
