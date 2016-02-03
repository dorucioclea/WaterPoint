using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.UserPrivileges;
using WaterPoint.Core.Domain.Requests.UserPrivileges;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.UserPrivileges
{
    public class AdjustUserPrivilegeProcessor : BaseCreateProcessor<AdjustUserPrivilegeRequest, AdjustUserPrivilege>
    {
        public AdjustUserPrivilegeProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<AdjustUserPrivilege> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override AdjustUserPrivilege BuildParameter(AdjustUserPrivilegeRequest input)
        {
            var parameter = new AdjustUserPrivilege
            {
                OrganizationId = input.OrganizationId,
                OrganizationUserId = input.OrganizationUserId,
                PrivilegeIds = string.Join(",", input.Payload.PrivilegeIds)
            };

            return parameter;
        }
    }
}
