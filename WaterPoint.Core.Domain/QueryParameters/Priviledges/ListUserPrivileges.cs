using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Priviledges
{
    public class ListUserPrivileges : IQueryParameter
    {
        public string OrgnizationUserIds { get; set; }
    }
}
