﻿using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Addresses;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Core.Domain.Requests.Addresses;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Addresses
{
    public class GetAddressForCustomerProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetAddressForCustomerRequest, AddressContract>
    {
        private readonly IQuery<GetAddressForCustomer, Address> _query;
        private readonly IQueryRunner _runner;

        public GetAddressForCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetAddressForCustomer, Address> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public AddressContract Process(GetAddressForCustomerRequest input)
        {
            var parameter = new GetAddressForCustomer
            {
                OrganizationId = input.OrganizationId,
                CustomerId = input.CustomerId,
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
