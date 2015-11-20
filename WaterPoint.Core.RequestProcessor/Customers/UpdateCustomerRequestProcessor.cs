using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Management.Instrumentation;
using System.Net;
using System.Web.Http.OData;
using WaterPoint.Core.Bll.Customers.Queries;
using WaterPoint.Core.Bll.Customers.Runners;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.RequestDtos;
using WaterPoint.Core.Domain.RequestDtos.Customers;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Customers
{
    public class UpdateCustomerRequestProcessor :
        BaseDapperUowRequestProcess,
        IUpdateRequestProcessor<OrganizationEntityRequest, Delta<UpdateCustomerRequest>, ResultContract<CustomerContract>>
    {
        private readonly GetCustomerByIdQuery _getCustomerByIdQuery;
        private readonly GetCustomerByIdQueryRunner _getCustomerByIdQueryRunner;

        public UpdateCustomerRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            GetCustomerByIdQuery getCustomerByIdQuery,
            GetCustomerByIdQueryRunner getCustomerByIdQueryRunner)
            : base(dapperUnitOfWork)
        {
            _getCustomerByIdQuery = getCustomerByIdQuery;
            _getCustomerByIdQueryRunner = getCustomerByIdQueryRunner;
        }


        public ResultContract<CustomerContract> Process(OrganizationEntityRequest pathInput, Delta<UpdateCustomerRequest> input)
        {
            throw new NotImplementedException();
            //_getCustomerByIdQuery.BuildQuery(pathInput.OrganizationId, pathInput.Id);

            //try
            //{
            //    using (DapperUnitOfWork.Begin())
            //    {
            //        //TODO: abstract this logic out, this is foreseeably repeating pattern
            //        var customer = _getCustomerByIdQueryRunner.Run(_getCustomerByIdQuery);

            //        if (customer == null)
            //        {
            //            //TODO: Add message to resource file.
            //            //TODO: detailLink
            //            throw new notfoundexception;
            //        }

            //        //TODO: Mapping prob just use reflection instead of auto-mapper
            //        var existingDto = OneToOneMapper.MapFrom<UpdateCustomerRequest>(customer);

            //        input.Patch(existingDto);

            //        var validationResults = new List<ValidationResult>();

            //        var isValidRequest = Validator.TryValidateObject(existingDto, null, validationResults);

            //        if (!isValidRequest)
            //        {
            //            foreach (var validationResult in validationResults)
            //            {
            //                //TODO: Add message to resource file.
            //                result.AddError(ProcessErrorCode.InvalidRequest, validationResult.ErrorMessage, "");
            //            }
            //        }



            //        throw new NotImplementedException();
            //    }
            //}
            //catch
            //{
            //    DapperUnitOfWork.Rollback();

            //    throw;
            //}
        }
    }
}
