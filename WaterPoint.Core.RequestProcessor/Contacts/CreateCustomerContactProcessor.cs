using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Core.Domain.Requests.Contacts;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Contacts
{
    public class CreateCustomerContactProcessor
        : BaseCreateProcessor<CreateCustomerContactRequest, CreateCustomerContact>
    {
        public CreateCustomerContactProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateCustomerContact> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CommandResult Process(CreateCustomerContactRequest input)
        {
            var result = UowProcess(Execute, input);

            return new ObjectsCountCommandResult(result, result > 0);
        }

        public override CreateCustomerContact BuildParameter(CreateCustomerContactRequest input)
        {
            return new CreateCustomerContact
            {
                CustomerId = input.CustomerId,
                IsPrimary = input.Payload.IsPrimary ?? false,
                ContactId = input.Payload.ContactId
            };
        }
    }
}
