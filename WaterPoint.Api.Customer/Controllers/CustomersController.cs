using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.Results;
using WaterPoint.Api.Common;
using WaterPoint.Api.Common.BaseControllers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Requests;
using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Core.RequestProcessor.Customers;
using CreateCustomerRequest = WaterPoint.Core.Domain.Requests.Customers.CreateCustomerRequest;

namespace WaterPoint.Api.Customer.Controllers
{
    [RoutePrefix(RouteDefinitions.Cusotmers.Prefix)]
    public class CusotmersController : BaseOrgnizationContextController
    {
        private readonly IRequestProcessor<OrganizationIdRequest, PaginationRequest, PaginatedResult<IEnumerable<BasicCustomerContract>>> _listCustomeRequestProcessor;
        private readonly ICreateRequestProcessor<OrganizationIdRequest, CreateCustomerRequest, BasicCustomerContract> _createCustomerRequest;
        private readonly IRequestProcessor<OrganizationEntityRequest, BasicCustomerContract> _getCustomerByIdProcessor;
        private readonly IUpdateRequestProcessor<OrganizationEntityRequest, UpdateCustomerRequest, BasicCustomerContract> _updateCustomerRequestProcessor;

        public CusotmersController(
            IRequestProcessor<OrganizationIdRequest, PaginationRequest, PaginatedResult<IEnumerable<BasicCustomerContract>>> listCustomeRequestProcessor,
            IRequestProcessor<OrganizationEntityRequest, BasicCustomerContract> getCustomerByIdProcessor,
            ICreateRequestProcessor<OrganizationIdRequest, CreateCustomerRequest, BasicCustomerContract> createCustomerRequest,
            IUpdateRequestProcessor<OrganizationEntityRequest, UpdateCustomerRequest, BasicCustomerContract> updateCustomerRequestProcessor)
        {
            _listCustomeRequestProcessor = listCustomeRequestProcessor;
            _createCustomerRequest = createCustomerRequest;
            _getCustomerByIdProcessor = getCustomerByIdProcessor;
            _updateCustomerRequestProcessor = updateCustomerRequestProcessor;
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

        [Route("")]
        [HttpPatch]
        public IHttpActionResult Patch(
            [FromUri]OrganizationEntityRequest request,
            [FromBody]Delta<UpdateCustomerRequest> input)
        {
            var f = new UpdateCustomerRequest();
            input.Patch(f);

            _updateCustomerRequestProcessor.Process(request, f);
            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put([FromUri]OrganizationEntityRequest request, [FromBody]object input)
        {
            throw new NotImplementedException();
        }
    }
}

