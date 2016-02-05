using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Credentials;

namespace WaterPoint.Core.Bll.Commands.Staff
{
    public class UndeleteStaffQueryByLoginEmailCommand : ICommand<UndeleteStaffByLoginEmail>
    {
        public void BuildQuery(UndeleteStaffByLoginEmail input)
        {
            Query = "[dbo].[Undelete_Staff_By_LoginEmail]";

            Parameters = new
            {
                organizationid = input.OrganizationId,
                loginemail = input.LoginEmail
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
