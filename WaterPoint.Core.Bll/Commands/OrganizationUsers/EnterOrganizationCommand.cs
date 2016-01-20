using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.OrganizationUsers;

namespace WaterPoint.Core.Bll.Commands.OrganizationUsers
{
    public class EnterOrganizationCommand : ICommand<EnterOrganization>
    {
        public void BuildQuery(EnterOrganization parameter)
        {
            Query = "[dbo].[Update_OrganizationUser_IsSignedIn]";

            Parameters = new
            {
                organizationid = parameter.OrganizationId,
                organizationuserid = parameter.OrganizationUserId,
                issignedin = parameter.IsSignedIn
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
