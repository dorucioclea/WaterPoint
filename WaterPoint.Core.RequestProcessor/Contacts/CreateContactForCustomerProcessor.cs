using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Core.Domain.Requests.Contacts;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Contacts
{
    public class CreateContactForCustomerProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<CreateContactForCustomerRequest>
    {
        private readonly ICommand<CreateContact> _command;
        private readonly ICommand<CreateCustomerContact> _createCustomerContactCommand;
        private readonly ICommandExecutor _executor;

        public CreateContactForCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateContact> command,
            ICommand<CreateCustomerContact> createCustomerContactCommand,
            ICommandExecutor executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _createCustomerContactCommand = createCustomerContactCommand;
            _executor = executor;
        }

        public CreateContact BuildParameter(CreateContactForCustomerRequest input)
        {
            return new CreateContact
            {
                OrganizationId = input.OrganizationId,
                IsDeleted = input.Payload.IsDeleted,
                Email = input.Payload.Email,
                FirstName = input.Payload.FirstName,
                LastName = input.Payload.LastName,
                MobilePhone = input.Payload.MobilePhone,
                OtherName = input.Payload.OtherName,
                Phone = input.Payload.Phone
            };
        }

        public CommandResult Process(CreateContactForCustomerRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CreateCommandResult(result, result > 0);
        }

        private int ProcessDeFacto(CreateContactForCustomerRequest input)
        {
            _command.BuildQuery(BuildParameter(input));

            var contactId = _executor.ExecuteInsert(_command);

            if (contactId == 0)
                return 0;

            _createCustomerContactCommand.BuildQuery(new CreateCustomerContact
            {
                CustomerId = input.CustomerId,
                IsPrimary = input.Payload.IsPrimary,
                ContactId = contactId
            });

            _executor.ExecuteInsert(_createCustomerContactCommand);

            return contactId;
        }
    }
}
