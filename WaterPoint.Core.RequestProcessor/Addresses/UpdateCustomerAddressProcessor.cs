using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Core.Domain.Requests.Addresses;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Addresses
{
    public class UpdateCustomerAddressProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<UpdateCustomerAddressRequest>
    {
        private readonly ICommand<UpdateCustomerAddressIsPostAddress> _updateCustomerAddressPost;
        private readonly ICommand<UpdateCustomerAddressIsPrimary> _updateCustomerAddressPrimary;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateCustomerAddressProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<UpdateCustomerAddressIsPostAddress> updateCustomerAddressPost,
            ICommand<UpdateCustomerAddressIsPrimary> updateCustomerAddressPrimary,
            ICommandExecutor updateCommandExecutor)
            :base(dapperUnitOfWork)
        {
            _updateCustomerAddressPost = updateCustomerAddressPost;
            _updateCustomerAddressPrimary = updateCustomerAddressPrimary;
            _commandExecutor = updateCommandExecutor;
        }


        public CommandResult Process(UpdateCustomerAddressRequest input)
        {
            var result = UowProcess(Execution, input);

            return new ObjectsCountCommandResult(result, result > 0);
        }

        public int Execution(UpdateCustomerAddressRequest input)
        {
            var entity = input.Payload.GetEntity();

            bool primaryUpdated = false, postaddressUpdated = false;

            if (entity.IsPrimary.HasValue)
            {
                _updateCustomerAddressPrimary.BuildQuery(new UpdateCustomerAddressIsPrimary
                {
                    CustomerId = input.CustomerId,
                    OrganizationId = input.OrganizationId,
                    IsPrimary = entity.IsPrimary.Value,
                    AddressId = input.Id
                });

                postaddressUpdated = _commandExecutor.ExecuteNonQuery(_updateCustomerAddressPrimary) > 0;
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

                primaryUpdated = _commandExecutor.ExecuteNonQuery(_updateCustomerAddressPost) > 0;
            }

            return (primaryUpdated || postaddressUpdated) ? 1 : 0;
        }
    }
}
