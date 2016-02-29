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
        private readonly ICommand<UpdateCustomerAddressIsPostAddress> _updateCustomerAddressPost;
        private readonly ICommand<UpdateCustomerAddressIsPrimary> _updateCustomerAddressPrimary;

        public UpdateAddressForCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            IQuery<GetAddress, Address> getQuery,
            IQueryRunner getQueryRunner,
            ICommand<UpdateAddress> updateQuery,
            ICommand<UpdateCustomerAddressIsPostAddress> updateCustomerAddressPost,
            ICommand<UpdateCustomerAddressIsPrimary> updateCustomerAddressPrimary,
            ICommandExecutor updateCommandExecutor)
            : base(dapperUnitOfWork, patchEntityAdapter, getQuery, getQueryRunner, updateQuery, updateCommandExecutor)
        {
            _updateCustomerAddressPost = updateCustomerAddressPost;
            _updateCustomerAddressPrimary = updateCustomerAddressPrimary;
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

            if (entity.IsPrimary.HasValue)
            {
                _updateCustomerAddressPrimary.BuildQuery(new UpdateCustomerAddressIsPrimary
                {
                    CustomerId = input.CustomerId,
                    OrganizationId = input.OrganizationId,
                    IsPrimary = entity.IsPrimary.Value,
                    AddressId = input.Id
                });

                CommandExecutor.ExecuteUpdate(_updateCustomerAddressPrimary);
            }

            if (entity.IsPostAddress.HasValue)
            {
                _updateCustomerAddressPost.BuildQuery(new UpdateCustomerAddressIsPostAddress
                {
                    CustomerId = input.CustomerId,
                    OrganizationId = input.OrganizationId,
                    AddressId = input.Id,
                    IsPostAddress = entity.IsPostAddress.Value
                });

                CommandExecutor.ExecuteUpdate(_updateCustomerAddressPost);
            }

            return value;
        }
    }
}
