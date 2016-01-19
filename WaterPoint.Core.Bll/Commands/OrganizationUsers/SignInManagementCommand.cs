using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.OrganizationUsers;

namespace WaterPoint.Core.Bll.Commands.OrganizationUsers
{
    public class SignInManagementCommand : ICommand<SignInManagement>
    {
        public void BuildQuery(SignInManagement parameter)
        {
            Query = "[dbo].[Update_OrganizationUser_IsSignedIn]";

            Parameters = new
            {
                organizationid = parameter.OrganizationId,
                organizationuserid = parameter.OrganizationUserId,
                credentialid = parameter.CredentialId,
                issignedin = parameter.IsSignedIn
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
