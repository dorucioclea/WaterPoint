using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WaterPoint.Core.Bll.Commands.Customers;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.Customers;
using WaterPoint.Core.Bll.QueryRunners.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Core.Domain.Dtos.Customers.Payloads;
using WaterPoint.Core.Domain.Dtos.Customers.Requests;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class UpdateCustomerRequestProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<UpdateCustomerRequest, CustomerContract>
    {
        private readonly GetCustomerByIdQuery _getCustomerByIdQuery;
        private readonly GetCustomerByIdQueryRunner _getCustomerByIdQueryRunner;
        private readonly UpdateCustomerByIdCommand _updateCustomerByIdQuery;
        private readonly UpdateCommandExecutor _updateCommandExecutor;

        public UpdateCustomerRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            GetCustomerByIdQuery getCustomerByIdQuery,
            GetCustomerByIdQueryRunner getCustomerByIdQueryRunner,
            UpdateCustomerByIdCommand updateCustomerByIdQuery,
            UpdateCommandExecutor updateCommandExecutor)
            : base(dapperUnitOfWork)
        {
            _getCustomerByIdQuery = getCustomerByIdQuery;
            _getCustomerByIdQueryRunner = getCustomerByIdQueryRunner;
            _updateCustomerByIdQuery = updateCustomerByIdQuery;
            _updateCommandExecutor = updateCommandExecutor;
        }

        public CustomerContract Process(UpdateCustomerRequest input)
        {
            var orgId = input.OrganizationEntityParameter.OrganizationId;

            var id = input.UpdateCustomerPayload.GetEntity().Id;

            _getCustomerByIdQuery.BuildQuery(orgId, id);

            try
            {
                using (DapperUnitOfWork.Begin())
                {
                    //TODO: abstract this logic out, this is foreseeably repeating pattern
                    var customer = _getCustomerByIdQueryRunner.Run(_getCustomerByIdQuery);

                    if (customer == null)
                    {
                        //TODO: Add message to resource file.
                        //TODO: detailLink
                        throw new NotFoundException();
                    }

                    //map to a dt
                    var existingDto = OneToOneMapper.MapFrom<UpdateCustomerPayload>(customer);

                    //patch the data
                    input.UpdateCustomerPayload.Patch(existingDto);

                    var validationResults = new List<ValidationResult>();

                    //validation
                    var isValidRequest = Validator.TryValidateObject(existingDto, null, validationResults);

                    if (!isValidRequest)
                    {
                        var exception = new InvalidInputDataException();

                        foreach (var validationResult in validationResults)
                            exception.AddMessage(validationResult.ErrorMessage);

                        throw exception;
                    }

                    //TODO: valid then update the object
                    var updatedCustomer = OneToOneMapper.MapFrom<Customer>(existingDto);

                    _updateCustomerByIdQuery.BuildQuery(orgId, updatedCustomer);

                    var success = _updateCommandExecutor.Run(_updateCustomerByIdQuery);

                    if (success)
                    {
                        DapperUnitOfWork.Commit();

                        return ContractMapper.CustomerMapper.Map(updatedCustomer);
                    }

                    var updateException = new UpdateFailedException();

                    updateException.AddMessage("operation is finished but there is no result returned");

                    throw updateException;
                }
            }
            catch (Exception ex)
            {
                DapperUnitOfWork.Rollback();

                var exception = new UpdateFailedException();

                exception.AddMessage(ex.InnerException.ToString());

                throw exception;
            }
        }
    }
}
