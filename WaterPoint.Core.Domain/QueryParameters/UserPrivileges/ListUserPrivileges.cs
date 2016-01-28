using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.UserPrivileges
{
    public class ListUserPrivileges : IQueryParameter
    {
        public string OrgnizationUserIds { get; set; }
    }
}
