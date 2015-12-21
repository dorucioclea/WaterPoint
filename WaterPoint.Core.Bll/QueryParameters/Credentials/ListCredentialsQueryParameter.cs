using WaterPoint.Core.Domain;

namespace WaterPoint.Core.Bll.QueryParameters.Credentials
{
    public class ListCredentialsQueryParameter : IQueryParameter
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
