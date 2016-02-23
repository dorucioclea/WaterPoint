using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Core.Domain.Requests.Addresses;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Addresses
{
    public class CreateAddressForCustomerProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<CreateAddressForCustomerRequest>
    {
        private readonly ICommand<CreateAddress> _command;
        private readonly ICommand<CreateCustomerAddress> _createCustomerAddressCommand;
        private readonly ICommandExecutor _executor;

        public CreateAddressForCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateAddress> command,
            ICommand<CreateCustomerAddress> createCustomerAddressCommand,
            ICommandExecutor executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _createCustomerAddressCommand = createCustomerAddressCommand;
            _executor = executor;
        }

        public CreateAddress BuildParameter(CreateAddressForCustomerRequest input)
        {
            return new CreateAddress
            {
                OrganizationId = input.OrganizationId,
                IsDeleted = input.Payload.IsDeleted,
                City = input.Payload.City,
                CountryId = input.Payload.CountryId,
                PostCode = input.Payload.PostCode,
                Province = input.Payload.Province,
                Street = input.Payload.Street,
                StreetExtraLine = input.Payload.StreetExtraLine,
                Suburb = input.Payload.Suburb
            };
        }

        public CommandResult Process(CreateAddressForCustomerRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CreateCommandResult(result, result > 0);
        }

        private int ProcessDeFacto(CreateAddressForCustomerRequest input)
        {
            _command.BuildQuery(BuildParameter(input));

            var addressId = _executor.ExecuteInsert(_command);

            if (addressId == 0)
                return 0;

            _createCustomerAddressCommand.BuildQuery(new CreateCustomerAddress
            {
                CustomerId = input.CustomerId,
                IsPrimary = input.Payload.IsPrimary ?? false,
                AddressId = addressId
            });

            _executor.ExecuteInsert(_createCustomerAddressCommand);

            return addressId;
        }
    }
}
