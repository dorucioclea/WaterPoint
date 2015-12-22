using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.Commands.Customers;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Bll.QueryParameters.Customers;
using WaterPoint.Core.Bll.QueryRunners.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Core.Domain.Dtos.Payloads.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class UpdateCustomerProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<UpdateCustomerRequest, CustomerContract>
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

        public CustomerContract Process(UpdateCustomerRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private CustomerContract ProcessDeFacto(UpdateCustomerRequest input)
        {
            var getCusParam = new GetCustomer
            {
                CustomerId = input.OrganizationEntityParameter.Id,
                OrganizationId = input.OrganizationEntityParameter.OrganizationId
            };

            _getCustomerByIdQuery.BuildQuery(getCusParam);

            var existingCustomer = _getCustomerByIdQueryRunner.Run(_getCustomerByIdQuery);

            var updatedCustomer = _patchEntityAdapter.PatchEnitity<WriteCustomerPayload, Customer, UpdateCustomer>(
                existingCustomer,
                input.UpdateCustomerPayload.Patch);

            var updateParameter = updatedCustomer.MapTo(new UpdateCustomer());

            //then build the query to update the object.
            _updateCustomerByIdQuery.BuildQuery(updateParameter);

            var success = _updateCommandExecutor.Execute(_updateCustomerByIdQuery) > 0;

            if (success)
                return CustomerMapper.Map(existingCustomer);

            var updateException = new UpdateFailedException();

            updateException.AddMessage("operation is finished but there is no result returned");

            throw updateException;
        }
    }



}
