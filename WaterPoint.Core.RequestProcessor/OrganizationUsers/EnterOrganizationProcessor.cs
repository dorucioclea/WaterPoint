using System;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.OrganizationUsers;
using WaterPoint.Core.Domain.Requests.OrganizationUsers;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.OrganizationUsers
{
    public class EnterOrganizationProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<EnterOrganizationRequest>
    {
        private readonly ICommand<EnterOrganization> _command;
        private readonly ICommandExecutor _executor;

        public EnterOrganizationProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<EnterOrganization> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public CommandResult Process(EnterOrganizationRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, result > 0);
        }

        private int ProcessDeFacto(EnterOrganizationRequest input)
        {
            var parameter = new EnterOrganization
            {
                OrganizationId = input.OrganizationId,
                OrganizationUserId = input.Id,
                IsSignedIn = input.Payload.ToSignIn
            };

            _command.BuildQuery(parameter);

            return _executor.ExecuteInsert(_command);
        }
    }
}
