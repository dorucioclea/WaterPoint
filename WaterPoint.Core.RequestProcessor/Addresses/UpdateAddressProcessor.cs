using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.Addresses;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Core.Domain.Requests.Addresses;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Addresses
{
    public class UpdateAddressProcessor:
        BaseUpdateProcessor<UpdateAddressRequest, WriteAddressPayload, UpdateAddress, GetAddress, Address>
    {
        public UpdateAddressProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            IQuery<GetAddress, Address> getQuery,
            IQueryRunner getQueryRunner,
            ICommand<UpdateAddress> updateQuery,
            ICommandExecutor updateCommandExecutor)
            : base(dapperUnitOfWork, patchEntityAdapter, getQuery, getQueryRunner, updateQuery, updateCommandExecutor)
        {
        }

        public override GetAddress BuildGetParameter(UpdateAddressRequest input)
        {
            return new GetAddress
            {
                Id = input.Id,
                OrganizationId = input.OrganizationId
            };
        }
    }
}
