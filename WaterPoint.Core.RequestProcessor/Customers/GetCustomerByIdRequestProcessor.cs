﻿using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Bll.QueryRunners.Customers;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Dtos.Customers.Requests;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class GetCustomerByIdRequestProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetCustomerByIdRequest, CustomerContract>
    {
        private readonly GetCustomerByIdQuery _command;
        private readonly GetCustomerByIdQueryRunner _runner;

        public GetCustomerByIdRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            GetCustomerByIdQuery command,
            GetCustomerByIdQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _runner = runner;
        }

        public CustomerContract Process(GetCustomerByIdRequest input)
        {
            _command.BuildQuery(input.OrganizationEntityParameter.OrganizationId, input.OrganizationEntityParameter.Id);

            using (DapperUnitOfWork.Begin())
            {
                var customer = _runner.Run(_command);

                var result = CustomerMapper.Map(customer);

                return result;
            }
        }
    }
}