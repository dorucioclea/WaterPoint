using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Web.Http.OData;
using WaterPoint.Core.Bll;
using WaterPoint.Core.Bll.Customers.Commands;
using WaterPoint.Core.Bll.Customers.Queries;
using WaterPoint.Core.Bll.Customers.Runners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Core.Domain.RequestDtos;
using WaterPoint.Core.Domain.RequestDtos.Customers;
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
        private readonly WriteCommandExecutor _writeCommandExecutor;

        public UpdateCustomerRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            GetCustomerByIdQuery getCustomerByIdQuery,
            GetCustomerByIdQueryRunner getCustomerByIdQueryRunner,
            UpdateCustomerByIdCommand updateCustomerByIdQuery,
            WriteCommandExecutor writeCommandExecutor
            ) : base(dapperUnitOfWork)
        {
            _getCustomerByIdQuery = getCustomerByIdQuery;
            _getCustomerByIdQueryRunner = getCustomerByIdQueryRunner;
            _updateCustomerByIdQuery = updateCustomerByIdQuery;
            _writeCommandExecutor = writeCommandExecutor;
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

                    _writeCommandExecutor.Run(_updateCustomerByIdQuery);

                    DapperUnitOfWork.Commit();
                }
            }
            catch
            {
                DapperUnitOfWork.Rollback();

                throw;
            }

            throw new NotImplementedException();
        }
    }
}
