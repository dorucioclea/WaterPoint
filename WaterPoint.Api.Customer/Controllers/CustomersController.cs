using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.Results;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.RequestDtos;
using WaterPoint.Core.Domain.RequestDtos.Customers;

namespace WaterPoint.Api.Customer.Controllers
{
    [RoutePrefix(RouteDefinitions.Cusotmers.Prefix)]
    public class CusotmersController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<OrganizationIdRequest, PaginationRequest, PaginatedResult<IEnumerable<CustomerContract>>> _listCustomeRequestProcessor;
        private readonly ICreateRequestProcessor<OrganizationIdRequest, CreateCustomerRequest, CustomerContract> _createCustomerRequest;
        //private readonly IUpdateRequestProcessor<OrganizationEntityRequest, Delta<UpdateCustomerRequest>, ProcessResult<CustomerContract>> _updateRequestProcessor;
        private readonly IRequestProcessor<OrganizationEntityRequest, CustomerContract> _getCustomerByIdProcessor;

        public CusotmersController(
            IRequestProcessor<OrganizationIdRequest, PaginationRequest, PaginatedResult<IEnumerable<CustomerContract>>> listCustomeRequestProcessor,
            IRequestProcessor<OrganizationEntityRequest, CustomerContract> getCustomerByIdProcessor,
            ICreateRequestProcessor<OrganizationIdRequest, CreateCustomerRequest, CustomerContract> createCustomerRequest
            //IUpdateRequestProcessor<OrganizationEntityRequest, Delta<UpdateCustomerRequest>, ProcessResult<CustomerContract>> updateRequestProcessor
            )
        {
            _listCustomeRequestProcessor = listCustomeRequestProcessor;
            _createCustomerRequest = createCustomerRequest;
            //_updateRequestProcessor = updateRequestProcessor;
            _getCustomerByIdProcessor = getCustomerByIdProcessor;
        }

        [Route("")]
        public IHttpActionResult Get(
            [FromUri]OrganizationIdRequest request,
            [FromUri]PaginationRequest pagination)
        {
            //validation
            var result = _listCustomeRequestProcessor.Process(request, pagination);

            return Ok(result);
        }

        [Route("{id:int}")]
        public IHttpActionResult Get([FromUri]OrganizationEntityRequest request)
        {
            var result = _getCustomerByIdProcessor.Process(request);

            return Ok(result);
        }

        [Route("")]
        public IHttpActionResult Post(
            [FromUri]OrganizationIdRequest request,
            [FromBody]CreateCustomerRequest customerInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _createCustomerRequest.Process(request, customerInput);

            return Ok(result);
        }

        //[Route("")]
        //public IHttpActionResult Put(
        //    [FromUri] OrganizationEntityRequest request,
        //    [FromBody] Delta<UpdateCustomerRequest> input)
        //{
        //    //map customer to an updatecustomerrequest so it gets all data
        //    //input.Patch(updatecustomerrequest) to get the patched value
        //    //pass patched value to processor
        //    _updateRequestProcessor.Process(request, input);
        //    return Ok();
        //}
    }
}

