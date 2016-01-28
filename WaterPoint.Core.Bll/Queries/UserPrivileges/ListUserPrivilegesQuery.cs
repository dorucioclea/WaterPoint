using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.UserPrivileges;

namespace WaterPoint.Core.Bll.Queries.Privileges
{
    public class ListUserPrivilegesQuery : IQuery<ListUserPrivileges>
    {
        public void BuildQuery(ListUserPrivileges parameter)
        {
            Query = "[dbo].[List_Privileges_By_UserIds]";
            Parameters = new
            {
                userIds = parameter.OrgnizationUserIds
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
