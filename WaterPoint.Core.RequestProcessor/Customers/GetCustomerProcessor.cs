﻿using AutoMapper.Internal;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Domain.QueryParameters.Customers;
//using WaterPoint.Core.Bll.QueryRunners.Customers;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class GetCustomerProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetCustomerRequest, CustomerContract>
    {
        private readonly IQuery<GetCustomer, Customer> _query;
        private readonly IQueryRunner _runner;

        public GetCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetCustomer, Customer> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public CustomerContract Process(GetCustomerRequest input)
        {
            var parameter = new GetCustomer
            {
                OrganizationId = input.OrganizationId,
                CustomerId = input.Id
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var customer = _runner.Run(_query);

                var result = CustomerMapper.Map(customer);

                return result;
            }
        }
    }
}
