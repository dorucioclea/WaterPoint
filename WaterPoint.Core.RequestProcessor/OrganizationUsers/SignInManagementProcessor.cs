using System;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.OrganizationUsers;
using WaterPoint.Core.Domain.Requests.OrganizationUsers;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.OrganizationUsers
{
    public class SignInManagementProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<SignInManagementRequest>
    {
        private readonly ICommand<SignInManagement> _command;
        private readonly ICommandExecutor<SignInManagement> _executor;

        public SignInManagementProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<SignInManagement> command,
            ICommandExecutor<SignInManagement> executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public CommandResult Process(SignInManagementRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, result > 0);
        }

        private int ProcessDeFacto(SignInManagementRequest input)
        {
            var parameter = new SignInManagement
            {
                OrganizationId = input.OrganizationId,
                OrganizationUserId = input.Id,
                IsSignedIn = input.Payload.IsSignedIn,
                CredentialId = input.Payload.CredentialId
            };

            _command.BuildQuery(parameter);

            return _executor.Execute(_command);
        }
    }
}
