using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.UserPrivileges;

namespace WaterPoint.Core.Bll.Commands.UserPrivileges
{
    public class AdjustUserPrivilegeCommand : ICommand<AdjustUserPrivilege>
    {
        public void BuildQuery(AdjustUserPrivilege input)
        {
            Query = "[dbo].[Add_OrganizationUser_Privileges]";

            Parameters = new
            {
                organizationid = input.OrganizationId,
                organizationuserid = input.OrganizationUserId,
                privilegeIds = input.PrivilegeIds
            };
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
