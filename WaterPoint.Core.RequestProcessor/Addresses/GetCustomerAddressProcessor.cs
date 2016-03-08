using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Addresses;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Core.Domain.Requests.Addresses;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Addresses;

namespace WaterPoint.Core.RequestProcessor.Addresses
{
    public class GetCustomerAddressProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetCustomerAddressRequest, CustomerAddressContract>
    {
        private readonly IQuery<GetCustomerAddress, CustomerAddressPoco> _query;
        private readonly IQueryRunner _runner;

        public GetCustomerAddressProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetCustomerAddress, CustomerAddressPoco> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public CustomerAddressContract Process(GetCustomerAddressRequest input)
        {
            var parameter = new GetCustomerAddress
            {
                OrganizationId = input.OrganizationId,
                CustomerId = input.CustomerId,
                IsDeleted = input.IsDeleted ?? false,
                Id = input.Id
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var contact = _runner.Run(_query);

                var result = AddressMapper.Map(contact);

                return result;
            }
        }
    }
}
