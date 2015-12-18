using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.Commands.Customers;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Bll.QueryRunners.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Core.Domain.Dtos.Payloads.Customers;
using WaterPoint.Core.Domain.Dtos.Requests.Customers;
using WaterPoint.Core.RequestProcessor.Mappers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class UpdateCustomerRequestProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<UpdateCustomerRequest, CustomerContract>
    {
        private readonly IPatchEntityAdapter _patchEntityAdapter;
        private readonly GetCustomerByIdQuery _getCustomerByIdQuery;
        private readonly GetCustomerByIdQueryRunner _getCustomerByIdQueryRunner;
        private readonly UpdateCustomerByIdCommand _updateCustomerByIdQuery;
        private readonly UpdateCommandExecutor _updateCommandExecutor;

        public UpdateCustomerRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            GetCustomerByIdQuery getCustomerByIdQuery,
            GetCustomerByIdQueryRunner getCustomerByIdQueryRunner,
            UpdateCustomerByIdCommand updateCustomerByIdQuery,
            UpdateCommandExecutor updateCommandExecutor)
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
            _getCustomerByIdQuery.BuildQuery(input.OrganizationEntityParameter.OrganizationId, input.OrganizationEntityParameter.Id);

            var existingCustomer = _getCustomerByIdQueryRunner.Run(_getCustomerByIdQuery);

            var updatedCustomer = _patchEntityAdapter.PatchEnitity<WriteCustomerPayload, Customer>(
                existingCustomer,
                input.UpdateCustomerPayload.Patch,
                (o) => { o.UtcUpdated = DateTime.UtcNow; },
                _getCustomerByIdQuery);

            //then build the query to update the object.
            _updateCustomerByIdQuery.BuildQuery(input.OrganizationEntityParameter.OrganizationId, updatedCustomer);

            var success = _updateCommandExecutor.Run(_updateCustomerByIdQuery);

            if (success)
                return CustomerMapper.Map(updatedCustomer);

            var updateException = new UpdateFailedException();

            updateException.AddMessage("operation is finished but there is no result returned");

            throw updateException;
        }
    }



}
