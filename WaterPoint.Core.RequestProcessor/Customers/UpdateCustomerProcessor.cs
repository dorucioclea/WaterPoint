using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.Commands.Customers;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Domain.QueryParameters.Customers;
//using WaterPoint.Core.Bll.QueryRunners.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Core.Domain.Payloads.Customers;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class UpdateCustomerProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<UpdateCustomerRequest, CommandResultContract>
    {
        private readonly IPatchEntityAdapter _patchEntityAdapter;
        private readonly IQuery<GetCustomer> _getCustomerByIdQuery;
        private readonly IQueryRunner<GetCustomer, Customer> _getCustomerByIdQueryRunner;
        private readonly ICommand<UpdateCustomer> _updateCustomerByIdQuery;
        private readonly ICommandExecutor<UpdateCustomer> _updateCommandExecutor;

        public UpdateCustomerProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            IQuery<GetCustomer> getCustomerByIdQuery,
            IQueryRunner<GetCustomer, Customer> getCustomerByIdQueryRunner,
            ICommand<UpdateCustomer> updateCustomerByIdQuery,
            ICommandExecutor<UpdateCustomer> updateCommandExecutor)
            : base(dapperUnitOfWork)
        {
            _patchEntityAdapter = patchEntityAdapter;
            _getCustomerByIdQuery = getCustomerByIdQuery;
            _getCustomerByIdQueryRunner = getCustomerByIdQueryRunner;
            _updateCustomerByIdQuery = updateCustomerByIdQuery;
            _updateCommandExecutor = updateCommandExecutor;
        }

        public CommandResultContract Process(UpdateCustomerRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResultContract(input.Parameter.Id, "customer", result > 0);
        }

        private int ProcessDeFacto(UpdateCustomerRequest input)
        {
            var getCusParam = new GetCustomer
            {
                CustomerId = input.Parameter.Id,
                OrganizationId = input.Parameter.OrganizationId
            };

            _getCustomerByIdQuery.BuildQuery(getCusParam);

            var existingCustomer = _getCustomerByIdQueryRunner.Run(_getCustomerByIdQuery);

            var updatedCustomer = _patchEntityAdapter.PatchEnitity<WriteCustomerPayload, Customer, UpdateCustomer>(
                existingCustomer,
                input.Payload.Patch);

            var updateParameter = updatedCustomer.MapTo(new UpdateCustomer());

            //then build the query to update the object.
            _updateCustomerByIdQuery.BuildQuery(updateParameter);

            return _updateCommandExecutor.Execute(_updateCustomerByIdQuery);
        }
    }
}
