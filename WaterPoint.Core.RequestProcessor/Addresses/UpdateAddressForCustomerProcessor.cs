using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.Addresses;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Core.Domain.Requests.Addresses;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Addresses
{
    public class UpdateAddressProcessor :
        BaseUpdateProcessor<UpdateAddressForCustomerRequest, WriteAddressPayload, UpdateAddress, GetAddressForCustomer, Address>
    {
        private readonly ICommand<UpdateCustomerAddress> _updateCustomerAddress;

        public UpdateAddressProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            IQuery<GetAddressForCustomer, Address> getQuery,
            IQueryRunner getQueryRunner,
            ICommand<UpdateAddress> updateQuery,
            ICommand<UpdateCustomerAddress> updateCustomerAddress,
            ICommandExecutor updateCommandExecutor)
            : base(dapperUnitOfWork, patchEntityAdapter, getQuery, getQueryRunner, updateQuery, updateCommandExecutor)
        {
            _updateCustomerAddress = updateCustomerAddress;
        }

        public override GetAddressForCustomer BuildGetParameter(UpdateAddressForCustomerRequest input)
        {
            return new GetAddressForCustomer
            {
                Id = input.Id,
                CustomerId = input.CustomerId,
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
                throw new InvalidOperationException();

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
