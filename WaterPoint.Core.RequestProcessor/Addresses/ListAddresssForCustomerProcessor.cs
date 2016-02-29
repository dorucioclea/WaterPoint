﻿using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Addresses;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Core.Domain.Requests.Addresses;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Addresses;

namespace WaterPoint.Core.RequestProcessor.Addresses
{
    public class ListAddressesForCustomerProcessor :
        BaseDapperUowRequestProcess,
        IListProcessor<ListAddressesForCustomerRequest, CustomerAddressContract>
    {
        private readonly IQuery<ListAddressesForCustomer, CustomerAddressPoco> _query;
        private readonly IQueryListRunner _runner;

        public ListAddressesForCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<ListAddressesForCustomer, CustomerAddressPoco> query,
            IQueryListRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public IEnumerable<CustomerAddressContract> Process(ListAddressesForCustomerRequest input)
        {
            _query.BuildQuery(new ListAddressesForCustomer
            {
                OrganizationId = input.OrganizationId,
                CustomerId = input.CustomerId,
                IsDeleted = input.IsDeleted ?? false
            });

            var result = _runner.Run(_query);

            return result.Select(AddressMapper.Map);
        }
    }
}