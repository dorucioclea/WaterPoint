using WaterPoint.Data.DbContext.Dapper;
using Utility;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Core.Domain.Requests.Contacts;

namespace WaterPoint.Core.RequestProcessor.Contacts
{
    public class CreateContactProcessor : BaseCreateProcessor<CreateContactRequest, CreateContact>
    {
        public CreateContactProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateContact> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateContact BuildParameter(CreateContactRequest input)
        {
            var createCustomer = input.Payload.MapTo(new CreateContact());

            createCustomer.OrganizationId = input.OrganizationId;

            return createCustomer;
        }
    }
}
