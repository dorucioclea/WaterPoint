using System.Linq;
using WaterPoint.Api.Common.Attributes;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Core.Domain.QueryParameters.OrganizationUsers;
using WaterPoint.Core.Domain.QueryParameters.Staff;
using WaterPoint.Core.Domain.QueryParameters.UserPrivileges;
using WaterPoint.Core.Domain.Requests.Staff;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Enums;
using OrgStaff = WaterPoint.Data.Entity.DataEntities.Staff;

namespace WaterPoint.Core.RequestProcessor.Staff
{
    public class CreateStaffProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<CreateStaffRequest>
    {
        private readonly IQuery<GetStaffByLoginEmail, OrgStaff> _getStaffByLogin;
        private readonly ICommand<UndeleteStaffByLoginEmail> _undeleteStaffCommand;
        private readonly ICommand<CreateCredential> _createCredential;
        private readonly ICommand<CreateOrganizationUser> _createOrganizationUser;
        private readonly ICommand<CreateStaff> _createStaffCommand;
        private readonly ICommand<AdjustUserPrivilege> _adjustUserPrivileges;
        private readonly ICommandExecutor _executor;
        private readonly IQueryRunner _queryRunner;

        public CreateStaffProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetStaffByLoginEmail, OrgStaff> getStaffByLogin,
            ICommand<UndeleteStaffByLoginEmail> undeleteStaffCommand,
            ICommand<CreateCredential> createCredential,
            ICommand<CreateOrganizationUser> createOrganizationUser,
            ICommand<CreateStaff> createStaffCommand,
            ICommand<AdjustUserPrivilege> adjustUserPrivileges,
            ICommandExecutor executor,
            IQueryRunner queryRunner)
            : base(dapperUnitOfWork)
        {
            _getStaffByLogin = getStaffByLogin;
            _undeleteStaffCommand = undeleteStaffCommand;
            _createCredential = createCredential;
            _createOrganizationUser = createOrganizationUser;
            _createStaffCommand = createStaffCommand;
            _adjustUserPrivileges = adjustUserPrivileges;
            _executor = executor;
            _queryRunner = queryRunner;
        }

        public virtual CommandResult Process(CreateStaffRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, result > 0);
        }

        private int ProcessDeFacto(CreateStaffRequest input)
        {
            //check staff with the same login exists or not
            _getStaffByLogin.BuildQuery(new GetStaffByLoginEmail
            {
                Email = input.Payload.Email,
                OrganizationId = input.OrganizationId
            });

            var alreadyCreatedStaff = _queryRunner.Run(_getStaffByLogin);

            if (alreadyCreatedStaff != null && alreadyCreatedStaff.IsDeleted)
            {
                //undelete
                _undeleteStaffCommand.BuildQuery(new UndeleteStaffByLoginEmail
                {
                    OrganizationId = input.OrganizationId,
                    LoginEmail = input.Payload.Email
                });
                var undeleted = _executor.ExecuteUpdate(_undeleteStaffCommand);

                if (undeleted > 0)
                    return alreadyCreatedStaff.Id;
            }

            //TODO: password provider
            //if not exists, will create one, otherwise use the existing one
            _createCredential.BuildQuery(new CreateCredential
            {
                Email = input.Payload.Email,
                Password = "password"
            });

            var credentialId = _executor.ExecuteInsert(_createCredential);

            _createOrganizationUser.BuildQuery(new CreateOrganizationUser
            {
                OrganizationId = input.OrganizationId,
                CredentialId = credentialId,
                OrganizationUserTypeId = input.Payload.IsAdmin
                    ? (int)OrganizationUserTypes.Admin
                    : (int)OrganizationUserTypes.Staff
            });

            var orgUserId = _executor.ExecuteInsert(_createOrganizationUser);

            _createStaffCommand.BuildQuery(new CreateStaff
            {
                OrganizationId = input.OrganizationId,
            });

            _createStaffCommand.BuildQuery(new CreateStaff
            {
                OrganizationId = input.OrganizationId,
                Code = input.Payload.Code,
                BaseRate = input.Payload.BaseRate,
                BillableRate = input.Payload.BillableRate,
                ContactEmail = input.Payload.ContactEmail,
                Dob = input.Payload.Dob,
                FirstName = input.Payload.FirstName,
                Gender = input.Payload.Gender,
                LastName = input.Payload.LastName,
                MobilePhone = input.Payload.MobilePhone,
                OrganizationUserId = orgUserId,
                OtherName = input.Payload.OtherName
            });

            var staffId = _executor.ExecuteInsert(_createStaffCommand);

            var privileges = string.Join(",", DefaultUserPrivileges.Admin.Select(i => ((int)i).ToString()));

            _adjustUserPrivileges.BuildQuery(new AdjustUserPrivilege
            {
                OrganizationId = input.OrganizationId,
                OrganizationUserId = orgUserId,
                PrivilegeIds = privileges
            });

            _executor.ExecuteInsert(_adjustUserPrivileges);

            return staffId;
        }
    }
}
