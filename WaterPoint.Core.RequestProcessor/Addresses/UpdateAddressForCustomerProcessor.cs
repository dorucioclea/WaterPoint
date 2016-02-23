using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Core.Domain.Payloads.Addresses;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Core.Domain.Requests.Addresses;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Addresses;

namespace WaterPoint.Core.RequestProcessor.Addresses
{
    public class UpdateAddressForCustomerProcessor :
        BaseUpdateProcessor<UpdateAddressForCustomerRequest, WriteAddressPayload, UpdateAddress, GetAddress, Address>
    {
        private readonly ICommand<UpdateCustomerAddress> _updateCustomerAddress;

        public UpdateAddressForCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            IQuery<GetAddress, Address> getQuery,
            IQueryRunner getQueryRunner,
            ICommand<UpdateAddress> updateQuery,
            ICommand<UpdateCustomerAddress> updateCustomerAddress,
            ICommandExecutor updateCommandExecutor)
            : base(dapperUnitOfWork, patchEntityAdapter, getQuery, getQueryRunner, updateQuery, updateCommandExecutor)
        {
            _updateCustomerAddress = updateCustomerAddress;
        }

        public override GetAddress BuildGetParameter(UpdateAddressForCustomerRequest input)
        {
            return new GetAddress
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId
            };
        }

        public override CommandResult Process(UpdateAddressForCustomerRequest input)
        {

            var result = UowProcess(Execution, input);

            return new CommandResult(result, result > 0);
        }

        public int Execution(UpdateAddressForCustomerRequest input)
        {
            var value = PatchExecution(input);

            if (!(value > 0))
                throw new NotFoundException();

            var entity = input.Payload.GetEntity();

            _updateCustomerAddress.BuildQuery(new UpdateCustomerAddress
            {
                CustomerId = input.CustomerId,
                OrganizationId = input.OrganizationId,
                IsPrimary = entity.IsPrimary,
                AddressId = input.Id,
                IsPostAddress = entity.IsPostAddress
            });

            return CommandExecutor.ExecuteUpdate(_updateCustomerAddress);
        }
    }
}
