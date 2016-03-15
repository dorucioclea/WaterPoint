using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Core.Domain.Requests.Addresses;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Addresses
{
    public class CreateCustomerAddressProcessor
        : BaseCreateProcessor<CreateCustomerAddressRequest, CreateCustomerAddress>
    {
        public CreateCustomerAddressProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateCustomerAddress> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CommandResult Process(CreateCustomerAddressRequest input)
        {
            var result = UowProcess(Execute, input);

            return new ObjectsCountCommandResult(result, result > 0);
        }

        public override CreateCustomerAddress BuildParameter(CreateCustomerAddressRequest input)
        {
            return new CreateCustomerAddress
            {
                CustomerId = input.CustomerId,
                IsPrimary = input.Payload.IsPrimary ?? false,
                AddressId = input.Payload.AddressId,
                IsPostAddress = input.Payload.IsPostAddress ?? false
            };
        }
    }
}
